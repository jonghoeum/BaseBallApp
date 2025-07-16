using BaseBallApp.Shared.Models;
using Blazorise;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
	public class RecruitService
	{
		private readonly HttpClient _http;
		public RecruitService(HttpClient http)
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

		public async Task<List<RecruitViewModel>> GetRecruitAsync(int pageNum, int pageSize)
		{
			string url = $"api/Recruit/Recruit?pageNumber={pageNum}&pageSize={pageSize}";
			return await _http.GetFromJsonAsync<List<RecruitViewModel>>(url);
		}

		public async Task<bool> InsertRecruitAsync(RecruitClass noti)
		{
			var response = await _http.PostAsJsonAsync("api/Recruit/insert", noti);
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
			var response = await _http.PostAsJsonAsync("api/Recruit/increment-view", idx);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateRecruitAsync(RecruitClass Recruit)
		{
			var response = await _http.PostAsJsonAsync("api/Recruit/update", Recruit);
			return response.IsSuccessStatusCode;
		}

        // 공지 상세 조회
        public async Task<RecruitClass?> GetRecruitByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<RecruitClass>($"api/Recruit/{id}");
        }
		public async Task<bool> DeleteRecruitAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/Recruit/delete/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
