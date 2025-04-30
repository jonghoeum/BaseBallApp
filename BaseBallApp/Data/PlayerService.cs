using BaseBallApp.Shared.Models;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
	public class PlayerService
	{
		private readonly HttpClient _http;
		public PlayerService(HttpClient http)
		{
			_http = http;
		}
		public string GetImageUrl(string fileName)
		{
			return $"{_http.BaseAddress}{fileName}";
		}

		public async Task<List<PlayersClass>> GetPlayersAsync()
		{
			return await _http.GetFromJsonAsync<List<PlayersClass>>("api/Players");
		}

		public async Task<bool> InsertPlayerAsync(PlayersClass players)
		{
			var response = await _http.PostAsJsonAsync("api/Players/insert", players);

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

		public async Task<bool> UpdatePlayerAsync(PlayersClass EditPlayer)
		{
			var response = await _http.PutAsJsonAsync($"api/Players/{EditPlayer.IDX}", EditPlayer);

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

		public async Task<bool> DeleteAsync(PlayersClass del)
		{
			var response = await _http.DeleteAsync($"api/Players/{del.IDX}");
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
