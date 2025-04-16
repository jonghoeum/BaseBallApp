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
		public async Task<ActionResult<IEnumerable<TrophyClass>>> Get()
		{
			//return await _db.Trophies.ToListAsync();
			var query = "SELECT * FROM dbo.Trophy";  // SQL 쿼리 작성
			var trophies = await _db.Trophies
										  .FromSqlRaw(query)
										  .ToListAsync();
			return Ok(trophies);

		}

	}
}
