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

		public async Task<bool> InsertGalleryAsync(GalleryClass gal)
		{
			//return await _http.PostAsJsonAsync("api/Games/insert", game);
			var response = await _http.PostAsJsonAsync("api/Gallery/insert", gal);
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("등록 성공");
				return true;
			}
			else //실패시
			{
				Console.WriteLine($"등록 실패: {response.StatusCode}");
				return false;
			}
		}
		public async Task<bool> DeleteGalleryAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/Gallery/delete/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
