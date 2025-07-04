using Microsoft.EntityFrameworkCore;
using BaseBallApp.Shared.Models;
namespace BaseBallApp.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<TrophyClass> Trophy { get; set; }
		public DbSet<PlayersClass> Players { get; set; }
		public DbSet<GameClass> Game { get; set; }
		public DbSet<GameScoreClass> GameScores { get; set; }
		public DbSet<GalleryClass> Gallery { get; set; }
		public DbSet<GalleryFiles> GalleryFiles { get; set; }
		public DbSet<NoticeClass> Notice { get; set; }
	}
}
