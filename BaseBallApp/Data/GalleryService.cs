using BaseBallApp.Shared.Models;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
	public class GalleryService
	{
		private readonly HttpClient _http;
		public GalleryService(HttpClient http)
		{
			_http = http;
		}
		public string GetImageUrl(string fileName)
		{
			return $"{_http.BaseAddress}{fileName}";
		}

		public async Task<List<GalleryClass>> GetGalleryAsync()
		{
			return await _http.GetFromJsonAsync<List<GalleryClass>>("api/Gallery/gallery");
		}
	}
}
