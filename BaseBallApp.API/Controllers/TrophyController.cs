using BaseBallApp.API.Data;
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
			return await _db.Trophies.ToListAsync();
		}

	}
}
