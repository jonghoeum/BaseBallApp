using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
	public class PlayersClass
	{
		[Key]
		public int? IDX { get; set; } = 0;
		public string? NO { get; set; }
		public string? NAME { get; set; }
		public DateTime? BIRTH { get; set; }
		public string? POSITION { get; set; }
		public string? STATURE { get; set; }
		public string? WEIGHT { get; set; }
		public string? OTHER1 { get; set; }
		public string? OTHER2 { get; set; }
		public string? OTHER3 { get; set; }
		public string? OTHER4 { get; set; }
		public string? OTHER5 { get; set; }
		public DateTime? REG_DATE { get; set; }
		public string FILE { get; set; }
		public string FILENAME { get; set; }

	}
}
