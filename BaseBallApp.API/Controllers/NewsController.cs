using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BaseBallApp.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NewsController : ControllerBase
	{
		private readonly AppDbContext _db;
		public NewsController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet("news")]
		public async Task<ActionResult<IEnumerable<NewsViewModel>>> GetNewsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var query = $@"
                WITH NewsWithRowNum AS (
                    SELECT 
                        CAST(ROW_NUMBER() OVER (ORDER BY CreatedAt DESC) AS INT) AS NO,
                        Idx, IsNotice, Title, Content, Other1, Other2, Other3, Other4, Other5, ViewCount, CreatedAt,
                        CAST(COUNT(*) OVER() AS BIGINT) AS TotalCount
                    FROM dbo.News
                )
                SELECT * 
                FROM NewsWithRowNum
                WHERE NO BETWEEN {(pageNumber - 1) * pageSize + 1} AND {pageNumber * pageSize}
                ORDER BY NO;
            ";
			return await _db.NewsViewModel.FromSqlRaw(query).ToListAsync();
		}

		[HttpPost("insert")]
		public async Task<IActionResult> InsertNewsAsync([FromBody] NewsClass request)
		{
			try
			{
				var sql = @"INSERT INTO dbo.News (IsNotice, Title, Content, ViewCount) VALUES (@p0, @p1, @p2, @p3)";
				var cmd = _db.Database.GetDbConnection().CreateCommand();
				cmd.CommandText = sql;
				cmd.Parameters.Add(new SqlParameter("@p0", request.IsNotice));
				cmd.Parameters.Add(new SqlParameter("@p1", request.Title ?? ""));
				cmd.Parameters.Add(new SqlParameter("@p2", request.Content ?? ""));
				cmd.Parameters.Add(new SqlParameter("@p3", request.ViewCount));

				await _db.Database.OpenConnectionAsync();
				await cmd.ExecuteNonQueryAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"INSERT 실패: {ex.Message}");
			}
		}

		[HttpPost("update")]
		public async Task<IActionResult> UpdateNewsAsync([FromBody] NewsClass request)
		{
			var news = await _db.News.FirstOrDefaultAsync(n => n.IDX == request.IDX);
			if (news == null) return NotFound();

			news.Title = request.Title;
			news.Content = request.Content;
			news.IsNotice = request.IsNotice;

			await _db.SaveChangesAsync();
			return Ok();
		}

		[HttpPost("increment-view")]
		public async Task<IActionResult> IncrementViewCount([FromBody] int idx)
		{
			var news = await _db.News.FirstOrDefaultAsync(n => n.IDX == idx);
			if (news == null) return NotFound();

			news.ViewCount += 1;
			await _db.SaveChangesAsync();
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<NewsClass>> GetNewsByIdAsync(int id)
		{
			return await _db.News.FirstOrDefaultAsync(n => n.IDX == id);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteNews(int id)
		{
			var news = await _db.News.FirstOrDefaultAsync(n => n.IDX == id);
			if (news == null) return NotFound();

			_db.News.Remove(news);
			await _db.SaveChangesAsync();
			return Ok();
		}
	}
}
