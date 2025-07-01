using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
	public class GalleryWithFile
	{
		//갤러리 클래스
		public GalleryClass Gallery { get; set; }
		//파일 클래스
		public List<GalleryFiles> GalleryFiles { get; set; }
		//public List<GameScoreClass> Scores { get; set; } = new();

	}
}
