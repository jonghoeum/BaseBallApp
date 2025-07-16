using BaseBallApp.Shared.Models;
using Blazorise;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
	public class NoticeService
	{
		private readonly HttpClient _http;
		public NoticeService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<NoticeViewModel>> GetNoticeAsync(int pageNum, int pageSize)
		{
			string url = $"api/Notice/notice?pageNumber={pageNum}&pageSize={pageSize}";
			return await _http.GetFromJsonAsync<List<NoticeViewModel>>(url);
		}

		public async Task<bool> InsertNoticeAsync(NoticeClass noti)
		{
			var response = await _http.PostAsJsonAsync("api/Notice/insert", noti);
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
			var response = await _http.PostAsJsonAsync("api/Notice/increment-view", idx);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateNoticeAsync(NoticeClass notice)
		{
			var response = await _http.PostAsJsonAsync("api/Notice/update", notice);
			return response.IsSuccessStatusCode;
		}

        // 공지 상세 조회
        public async Task<NoticeClass?> GetNoticeByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<NoticeClass>($"api/Notice/{id}");
        }
		public async Task<bool> DeleteNoticeAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/Notice/delete/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
