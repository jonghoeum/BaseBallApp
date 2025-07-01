using BaseBallApp.Pages;
using BaseBallApp.Shared.Models;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
    public class GameService
    {
        private readonly HttpClient _http;
        public GameService(HttpClient http)
        {
            _http = http;
        }
        public string GetImageUrl(string fileName)
        {
            return $"{_http.BaseAddress}{fileName}";
        }

        public async Task<List<GameClass>> GetGamesAsync()
        {
            return await _http.GetFromJsonAsync<List<GameClass>>("api/Games/games");
        }

        public async Task<List<GameScoreClass>> GetGamesScoreAsync()
        {
            return await _http.GetFromJsonAsync<List<GameScoreClass>>("api/Games/gamescore");
        }
        public async Task<bool> InsertGameAsync(GameWithScores game)
        {
            //return await _http.PostAsJsonAsync("api/Games/insert", game);
            var response = await _http.PostAsJsonAsync("api/Games/insert", game);
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
        public async Task<bool> EditGameAsync(GameWithScores game)
        {
            //return await _http.PostAsJsonAsync("api/Games/insert", game);
            var response = await _http.PostAsJsonAsync("api/Games/edit", game);
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

        public async Task<bool> DeleteItemAsync(string id)
        {
            var response = await _http.DeleteAsync($"api/Games/delete/{id}");
            if(response.IsSuccessStatusCode)
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
