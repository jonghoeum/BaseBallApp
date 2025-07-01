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
		public async Task<ActionResult<IEnumerable<GameClass>>> GetGalleryAsync()
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
	}
}
