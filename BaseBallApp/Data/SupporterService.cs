using BaseBallApp.Shared.Models;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
    public class SupporterService
    {
		private readonly HttpClient _http;
		public SupporterService(HttpClient http)
		{
			_http = http;
		}
		public string GetDownloadUrl(string? relativePath)
		{
			if (string.IsNullOrWhiteSpace(relativePath))
				return string.Empty;

			// Ensure there is no leading '/' in BaseAddress
			var baseUri = _http.BaseAddress?.ToString().TrimEnd('/');
			var encodedPath = Uri.EscapeUriString(relativePath.TrimStart('/'));

			return $"{baseUri}/{encodedPath}";
		}

		public async Task<List<SupportersViewModel>> GetSupportersAsync(int pageNum, int pageSize)
		{
			string url = $"api/Supporters/Supporters?pageNumber={pageNum}&pageSize={pageSize}";
			return await _http.GetFromJsonAsync<List<SupportersViewModel>>(url);
		}

		public async Task<bool> InsertSupportersAsync(SupportersClass noti)
		{
			var response = await _http.PostAsJsonAsync("api/Supporters/insert", noti);
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

		public async Task<bool> IncrementViewCountAsync(int idx)
		{
			var response = await _http.PostAsJsonAsync("api/Supporters/increment-view", idx);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateSupportersAsync(SupportersClass Supporters)
		{
			var response = await _http.PostAsJsonAsync("api/Supporters/update", Supporters);
			return response.IsSuccessStatusCode;
		}

		// 공지 상세 조회
		public async Task<SupportersClass?> GetSupportersByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<SupportersClass>($"api/Supporters/{id}");
		}
		public async Task<bool> DeleteSupportersAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/Supporters/delete/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
