using BaseBallApp.Pages;
using BaseBallApp.Shared.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;


namespace BaseBallApp.Data
{
	public class TrophyService
	{
		private readonly HttpClient _http;

		public TrophyService(HttpClient http)
		{
			_http = http;
		}
		public string GetImageUrl(string fileName)
		{
			return $"{_http.BaseAddress}{fileName}";
		}

		public async Task<List<TrophyClass>> GetTrophiesAsync()
		{
			return await _http.GetFromJsonAsync<List<TrophyClass>>("api/Trophy");
		}
		public async Task<bool> InsertTrophyAsync(TrophyClass trophy)
		{
			var response = await _http.PostAsJsonAsync("api/trophy/insert", trophy);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("등록 성공");
				return true;
			}
			else
			{
				Console.WriteLine($"등록 실패: {response.StatusCode}");
				return false;
			}
		}

		public async Task<bool> UpdateTrophyAsync(TrophyClass EditTrophy)
		{
			var response = await _http.PutAsJsonAsync($"api/trophy/{EditTrophy.IDX}", EditTrophy);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("등록 성공");
				return true;
			}
			else
			{
				Console.WriteLine($"등록 실패: {response.StatusCode}");
				return false;
			}

		}

		public async Task<bool>DeleteAsync(TrophyClass del)
		{
			var response = await _http.DeleteAsync($"api/trophy/{del.IDX}");
			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
