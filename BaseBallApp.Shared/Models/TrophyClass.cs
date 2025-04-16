using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace BaseBallApp.Shared.Models
{
	public class TrophyClass
	{
		[Key]
		public int? IDX { get; set; } = 0;
		public string TITLE { get; set; }
		public string CONTENT { get; set; }
		public string FILE { get; set; }
		public string FILENAME { get; set; }
		public int? USE { get; set; } = 0;
		public DateTime? REG_DATE { get; set; }
	}
}
