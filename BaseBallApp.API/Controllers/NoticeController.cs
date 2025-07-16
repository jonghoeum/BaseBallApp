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
	public class NoticeController : ControllerBase
	{
		private readonly AppDbContext _db;

		public NoticeController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet("notice")]
		public async Task<ActionResult<IEnumerable<NoticeViewModel>>> GetNoticeAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var query = $@"
								WITH NoticeWithRowNum AS (
									SELECT 
										CAST(ROW_NUMBER() OVER (ORDER BY CreatedAt DESC) AS INT) AS NO,
										Idx,
										IsNotice,
										Title,
										Content,
										Other1,
										Other2,
										Other3,
										Other4,
										Other5,
										ViewCount,
										CreatedAt,
										CAST(COUNT(*) OVER() AS BIGINT) AS TotalCount
									FROM dbo.Notice
								)
								SELECT * 
								FROM NoticeWithRowNum
								WHERE NO BETWEEN {(pageNumber - 1) * pageSize + 1} AND {pageNumber * pageSize}
								ORDER BY NO;
							";

				var rawResult = await _db.NoticeViewModel.FromSqlRaw(query).ToListAsync();
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
		public async Task<IActionResult> InsertNoticeAsync([FromBody] NoticeClass request)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var sql = @"
                            INSERT INTO dbo.Notice (isNotice, Title, Content, ViewCount)
                            VALUES (@p0, @p1, @p2, @p3);
                            ";

				using var cmd = _db.Database.GetDbConnection().CreateCommand();
				cmd.CommandText = sql;
				cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

				cmd.Parameters.Add(new SqlParameter("@p0", (object?)request.IsNotice ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p1", (object?)request.Title ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p2", (object?)request.Content ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p3", (object?)request.ViewCount ?? DBNull.Value));

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
				var notice = await _db.Notice.FirstOrDefaultAsync(n => n.IDX == idx);
				if (notice == null)
					return NotFound();

				notice.ViewCount += 1;
				await _db.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"조회수 증가 실패: {ex.Message}");
			}
		}

		[HttpPost("update")]
		public async Task<IActionResult> UpdateNoticeAsync([FromBody] NoticeClass request)
		{
			try
			{
				var notice = await _db.Notice.FirstOrDefaultAsync(n => n.IDX == request.IDX);
				if (notice == null) return NotFound();

				notice.Title = request.Title;
				notice.Content = request.Content;
				notice.IsNotice = request.IsNotice;

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
        public async Task<ActionResult<NoticeClass>> GetNoticeByIdAsync(int id)
        {
            try
            {
                var query = $@"
                SELECT TOP 1
                    Idx,
                    IsNotice,
                    Title,
                    Content,
                    Other1,
                    Other2,
                    Other3,
                    Other4,
                    Other5,
                    ViewCount,
                    CreatedAt
                FROM dbo.Notice
                WHERE Idx = @id";

                var param = new SqlParameter("@id", id);
                var result = await _db.Notice.FromSqlRaw(query, param).FirstOrDefaultAsync();

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
		public async Task<IActionResult> DeleteNotice(int id)
		{
			try
			{
				var notice = await _db.Notice.FirstOrDefaultAsync(n => n.IDX == id);
				if (notice == null) return NotFound();

				_db.Notice.Remove(notice);
				await _db.SaveChangesAsync();

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"삭제 실패: {ex.Message}");
			}
		}
	}
}