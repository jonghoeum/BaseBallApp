using BaseBallApp.Shared.Models;
using Blazorise;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
	public class NewsService
	{
		private readonly HttpClient _http;
		public NewsService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<NewsViewModel>> GetNewsAsync(int pageNum, int pageSize)
		{
			return await _http.GetFromJsonAsync<List<NewsViewModel>>($"api/News/news?pageNumber={pageNum}&pageSize={pageSize}");
		}

		public async Task<bool> InsertNewsAsync(NewsClass news)
		{
			var response = await _http.PostAsJsonAsync("api/News/insert", news);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateNewsAsync(NewsClass news)
		{
			var response = await _http.PostAsJsonAsync("api/News/update", news);
			return response.IsSuccessStatusCode;
		}

		public async Task<NewsClass?> GetNewsByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<NewsClass>($"api/News/{id}");
		}

		public async Task<bool> DeleteNewsAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/News/delete/{id}");
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> IncrementViewCountAsync(int idx)
		{
			var response = await _http.PostAsJsonAsync("api/News/increment-view", idx);
			return response.IsSuccessStatusCode;
		}
	}
}
