using Microsoft.EntityFrameworkCore;

namespace BaseBallApp.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TrophyClass> Trophies { get; set; }
	}
}
