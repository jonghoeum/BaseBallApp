using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
	public class GalleryClass
	{
		[Key]
		public int IDX { get; set; } = 0;
		[Required(ErrorMessage = "제목을 입력하세요.")]
		public string? TITLE { get; set; }
		//[Required(ErrorMessage = "내용을 입력하세요.")]
		public string? CONTENT { get; set; }
		public string? FILE { get; set; }
		public string? FILENAME { get; set; }
		public string? REF_IDX { get; set; }
		public string? OTHER2 { get; set; }
		public string? OTHER3 { get; set; }
		public string? OTHER4 { get; set; }
		public string? OTHER5 { get; set; }
		public DateTime? REG_DATE { get; set; }
	}
}
