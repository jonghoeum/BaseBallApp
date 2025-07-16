using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BaseBallApp.Shared.Models
{
	[Keyless]
	public class NewsViewModel
	{
		public int IDX { get; set; } = 0;
		public bool IsNotice { get; set; } = false;

		[Required(ErrorMessage = "제목을 입력하세요.")]
		public string? Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "내용을 입력하세요.")]
		public string? Content { get; set; } = string.Empty;

		public string? Other1 { get; set; }
		public string? Other2 { get; set; }
		public string? Other3 { get; set; }
		public string? Other4 { get; set; }
		public string? Other5 { get; set; }

		public int ViewCount { get; set; }
		public DateTime CreatedAt { get; set; }

		public int No { get; set; }
		public long TotalCount { get; set; }
	}
}
