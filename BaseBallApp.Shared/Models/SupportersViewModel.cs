using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
	[Keyless]
	public class SupportersViewModel
	{
		public int IDX { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }
		public bool IsNotice { get; set; }
		public string? FileName1 { get; set; }
		public string? FilePath1 { get; set; }
		public int ViewCount { get; set; }
		public DateTime CreatedAt { get; set; }
		public int No { get; set; }
		public long TotalCount { get; set; }
	}
}
