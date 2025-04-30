using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace BaseBallApp.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlayersController : ControllerBase
	{
		private readonly AppDbContext _db;
		public PlayersController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PlayersClass>>> GetPlayersAsync()
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var query = "SELECT * FROM dbo.Players";
				var players = await _db.Players
										.FromSqlRaw(query)
										.ToListAsync();

				await transaction.CommitAsync();  // 성공 시 커밋
				return Ok(players);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();  // 실패 시 롤백
				return StatusCode(500, $"오류 발생: {ex.Message}");
			}
		}

		[HttpPost("insert")]
		public async Task<IActionResult> InsertPlayer([FromBody] PlayersClass request)
		{
			using var transaction = await _db.Database.BeginTransactionAsync();

			try
			{
				var sql = "INSERT INTO dbo.Players (NO, NAME, BIRTH, POSITION, STATURE, WEIGHT, [FILE], FILENAME) VALUES (@P0, @P1, @P2, @P3, @P4, @P5, @P6, @P7)";
				var result = await _db.Database.ExecuteSqlRawAsync(sql, request.NO, request.NAME, request.BIRTH, request.POSITION, request.STATURE, request.WEIGHT, request.FILE, request.FILENAME);

				await transaction.CommitAsync();
				return Ok($"{result}개의 행이 추가되었습니다.");
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, $"INSERT 실패: {ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTrophy(int id, [FromBody] PlayersClass dto)
		{
			var player = await _db.Players.FindAsync(id);
			if (player == null) return NotFound();

			player.NO = dto.NO;
			player.NAME = dto.NAME;
			player.BIRTH = dto.BIRTH;
			player.POSITION = dto.POSITION;
			player.STATURE = dto.STATURE;
			player.WEIGHT = dto.WEIGHT;
			player.OTHER1 = dto.OTHER1;
			player.OTHER2 = dto.OTHER2;
			player.OTHER3 = dto.OTHER3;
			player.OTHER4 = dto.OTHER4;
			player.OTHER5 = dto.OTHER5;
			player.REG_DATE = dto.REG_DATE;
			player.FILE = dto.FILE;
			player.FILENAME = dto.FILENAME;
			
			using var transaction = await _db.Database.BeginTransactionAsync();
			try
			{
				var sql = "UPDATE dbo.Players SET  [NO] = @P0, NAME = @P1, BIRTH = @P2, POSITION = @P3, STATURE = @P4, WEIGHT = @P5, OTHER1 = @P6, OTHER2 = @P7, OTHER3 = @P8, OTHER4 = @P9, OTHER5 = @P10,  [FILE] = @P11 , FILENAME = @P12 WHERE IDX = @P13";
				var result = await _db.Database.ExecuteSqlRawAsync(sql,
					player.NO,
					player.NAME,
					player.BIRTH,     // ✅ DateTime? 그대로
					player.POSITION,
					player.STATURE,
					player.WEIGHT,
					player.OTHER1,
					player.OTHER2,
					player.OTHER3,
					player.OTHER4,
					player.OTHER5,
					player.FILE,
					player.FILENAME,
					player.IDX
				);
				await transaction.CommitAsync();
				return Ok($"{result}개의 행이 수정되었습니다.");
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, $"Update 실패: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlayer(int id)
		{
			var player = await _db.Players.FindAsync(id);
			if (player == null) return NotFound(new { success = false, message = "데이터를 찾을 수 없습니다." });

			_db.Players.Remove(player);
			await _db.SaveChangesAsync();
			return Ok(new { success = true, message = "삭제가 완료되었습니다." });
		}
	}
}
