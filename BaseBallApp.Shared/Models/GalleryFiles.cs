using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
	public class GalleryFiles
	{
		[Key]
		public int IDX { get; set; }
		public string REF_IDX { get; set; }

		public string FILE { get; set; } = "";
		public string FILENAME { get; set; } = "";
		public long FileSize { get; set; }
		public string? FileExtension { get; set; }
		public DateTime UploadTime { get; set; } = DateTime.Now;
		
	}
}
