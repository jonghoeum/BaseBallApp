using Microsoft.EntityFrameworkCore;
using BaseBallApp.Shared.Models;
namespace BaseBallApp.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TrophyClass> Trophy { get; set; }

		public DbSet<PlayersClass> Players { get; set; }
		public DbSet<GameClass> Games { get; set; }
		public DbSet<GameScoreClass> GameScores { get; set; }
	}
}
