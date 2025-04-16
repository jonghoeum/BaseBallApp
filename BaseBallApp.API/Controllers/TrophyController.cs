using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BaseBallApp.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TrophyController : ControllerBase
	{
		private readonly AppDbContext _db;

		public TrophyController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TrophyClass>>> GetTrophiesAsync()
		{

			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var query = "SELECT * FROM dbo.Trophy";
				var trophies = await _db.Trophies
										.FromSqlRaw(query)
										.ToListAsync();

				await transaction.CommitAsync();  // 성공 시 커밋
				return Ok(trophies);
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

			var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
			Directory.CreateDirectory(uploadsFolder);

			var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
			var fullFilePath = Path.Combine(uploadsFolder, uniqueFileName);

			using (var stream = new FileStream(fullFilePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			var relativePath = $"uploads/{uniqueFileName}"; // 클라이언트에 전달할 경로
			return Ok(relativePath);
		}

		[HttpPost("insert")]
		public async Task<IActionResult> InsertTrophy([FromForm] TrophyClass request)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var sql = "INSERT INTO dbo.Trophy (TITLE, CONTENT, [FILE], FILENAME) VALUES (@P0, @P1, @P2, @P3)";
				var result = await _db.Database.ExecuteSqlRawAsync(sql, request.TITLE, request.CONTENT, request.FILE,request.FILENAME);

				await transaction.CommitAsync();
				return Ok($"{result}개의 행이 추가되었습니다.");
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, $"INSERT 실패: {ex.Message}");
			}
		}

	}
}
