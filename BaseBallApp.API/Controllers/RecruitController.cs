using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseBallApp.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecruitController : ControllerBase
	{
		private readonly AppDbContext _db;

		public RecruitController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet("Recruit")]
		public async Task<ActionResult<IEnumerable<RecruitViewModel>>> GetRecruitAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var query = $@"
								WITH RecruitWithRowNum AS (
									SELECT 
										CAST(ROW_NUMBER() OVER (ORDER BY CreatedAt DESC) AS INT) AS NO,
										Idx,
										IsNotice,
										Title,
										Content,
										FileName1,
										FilePath1,
										FileName2,
										FilePath2,
										ViewCount,
										CreatedAt,
										CAST(COUNT(*) OVER() AS BIGINT) AS TotalCount
									FROM dbo.Recruit
								)
								SELECT * 
								FROM RecruitWithRowNum
								WHERE NO BETWEEN {(pageNumber - 1) * pageSize + 1} AND {pageNumber * pageSize}
								ORDER BY NO;
							";

				var rawResult = await _db.RecruitViewModel.FromSqlRaw(query).ToListAsync();
				await transaction.CommitAsync();
				return Ok(rawResult);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, $"오류 발생: {ex.Message}");
			}
		}

		[HttpPost("insert")]
		public async Task<IActionResult> InsertRecruitAsync([FromBody] RecruitClass request)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var sql = @"
                            INSERT INTO dbo.Recruit (isNotice, Title, Content, ViewCount, FileName1, FilePath1, FileName2, FilePath2)
                            VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7);
                            ";

				using var cmd = _db.Database.GetDbConnection().CreateCommand();
				cmd.CommandText = sql;
				cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

				cmd.Parameters.Add(new SqlParameter("@p0", (object?)request.IsNotice ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p1", (object?)request.Title ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p2", (object?)request.Content ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p3", (object?)request.ViewCount ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p4", (object?)request.FileName1 ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p5", (object?)request.FilePath1 ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p6", (object?)request.FileName2 ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p7", (object?)request.FilePath2 ?? DBNull.Value));

				await _db.Database.OpenConnectionAsync();
				var result = await cmd.ExecuteScalarAsync();

				await transaction.CommitAsync();
				return Ok();
				//return Ok($"{result}개의 행이 추가되었습니다.");
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, $"INSERT 실패: {ex.Message}");
			}
		}

		[HttpPost("increment-view")]
		public async Task<IActionResult> IncrementViewCount([FromBody] int idx)
		{
			try
			{
				var Recruit = await _db.Recruit.FirstOrDefaultAsync(n => n.IDX == idx);
				if (Recruit == null)
					return NotFound();

				Recruit.ViewCount += 1;
				await _db.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"조회수 증가 실패: {ex.Message}");
			}
		}

		[HttpPost("update")]
		public async Task<IActionResult> UpdateRecruitAsync([FromBody] RecruitClass request)
		{
			try
			{
				var Recruit = await _db.Recruit.FirstOrDefaultAsync(n => n.IDX == request.IDX);
				if (Recruit == null) return NotFound();

				Recruit.Title = request.Title;
				Recruit.Content = request.Content;
				Recruit.IsNotice = request.IsNotice;
				Recruit.FileName1 = request.FileName1;
				Recruit.FilePath1 = request.FilePath1;
				Recruit.FileName2 = request.FileName2;
				Recruit.FilePath2 = request.FilePath2;

				await _db.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"UPDATE 실패: {ex.Message}");
			}
		}

        // 공지 상세 조회
        [HttpGet("{id}")]
        public async Task<ActionResult<RecruitClass>> GetRecruitByIdAsync(int id)
        {
            try
            {
                var query = $@"
                SELECT TOP 1
                    Idx,
                    IsNotice,
                    Title,
                    Content,
                    FileName1,
					FilePath1,
					FileName2,
					FilePath2,
                    ViewCount,
                    CreatedAt
                FROM dbo.Recruit
                WHERE Idx = @id";

                var param = new SqlParameter("@id", id);
                var result = await _db.Recruit.FromSqlRaw(query, param).FirstOrDefaultAsync();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"상세 조회 실패: {ex.Message}");
            }
        }
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteRecruit(int id)
		{
			try
			{
				var Recruit = await _db.Recruit.FirstOrDefaultAsync(n => n.IDX == id);
				if (Recruit == null) return NotFound();

				_db.Recruit.Remove(Recruit);
				await _db.SaveChangesAsync();

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"삭제 실패: {ex.Message}");
			}
		}

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("파일이 없습니다.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "recruit");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullFilePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var relativePath = $"/recruit/{uniqueFileName}"; // 클라이언트에 전달할 경로
            return Ok(relativePath);
        }

    }
}