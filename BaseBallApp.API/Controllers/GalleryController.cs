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
	public class GalleryController : ControllerBase
	{
		private readonly AppDbContext _db;
		public GalleryController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet("gallery")]
		public async Task<ActionResult<IEnumerable<GalleryClass>>> GetGalleryAsync()
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var query = @"SELECT 
                            *
                        FROM 
                            BaseBall.dbo.Gallery
                        ";
				var gallery = await _db.Gallery
										.FromSqlRaw(query)
										.ToListAsync();

				await transaction.CommitAsync();  // 성공 시 커밋
				return Ok(gallery);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();  // 실패 시 롤백
				return StatusCode(500, $"오류 발생: {ex.Message}");
			}
		}

		[HttpPost("upload")]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest("파일이 없습니다.");

			var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "gallery");
			Directory.CreateDirectory(uploadsFolder);

			var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
			var fullFilePath = Path.Combine(uploadsFolder, uniqueFileName);

			using (var stream = new FileStream(fullFilePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			var relativePath = $"/gallery/{uniqueFileName}"; // 클라이언트에 전달할 경로
			return Ok(relativePath);
		}
		[HttpPost("insert")]
		public async Task<IActionResult> InsertGalleryAsync([FromBody] GalleryClass request)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var sql = @"
                            INSERT INTO dbo.Gallery (TITLE, CONTENT, [FILE], FILENAME)
                            VALUES (@p0, @p1, @p2, @p3);
                            ";

				using var cmd = _db.Database.GetDbConnection().CreateCommand();
				cmd.CommandText = sql;
				cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

				cmd.Parameters.Add(new SqlParameter("@p0", (object?)request.TITLE ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p1", (object?)request.CONTENT ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p2", (object?)request.FILE ?? DBNull.Value));
				cmd.Parameters.Add(new SqlParameter("@p3", (object?)request.FILENAME ?? DBNull.Value));


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
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteGalleryAsync(int id)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var gallery = await _db.Gallery.FirstOrDefaultAsync(g => g.IDX == id);
				if (gallery == null)
					return NotFound("해당 항목이 없습니다.");

				_db.Gallery.Remove(gallery);
				await _db.SaveChangesAsync();
				await transaction.CommitAsync();

				return Ok();
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, $"삭제 실패: {ex.Message}");
			}
		}
	}
}
