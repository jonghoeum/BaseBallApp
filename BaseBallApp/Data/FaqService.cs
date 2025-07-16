using BaseBallApp.Shared.Models;
using System.Net.Http.Json;

namespace BaseBallApp.Data
{
    public class FaqService
    {
        private readonly HttpClient _http;
        public FaqService(HttpClient http) => _http = http;

        public string GetDownloadUrl(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return string.Empty;
            var baseUri = _http.BaseAddress?.ToString().TrimEnd('/');
            var encodedPath = Uri.EscapeUriString(relativePath.TrimStart('/'));
            return $"{baseUri}/{encodedPath}";
        }

        public async Task<List<FaqViewModel>> GetFaqsAsync(int pageNum, int pageSize)
        {
            string url = $"api/Faq/Faqs?pageNumber={pageNum}&pageSize={pageSize}";
            return await _http.GetFromJsonAsync<List<FaqViewModel>>(url);
        }

        public async Task<FaqClass?> GetFaqByIdAsync(int id) =>
            await _http.GetFromJsonAsync<FaqClass>($"api/Faq/{id}");

        public async Task<bool> InsertFaqAsync(FaqClass faq) =>
            (await _http.PostAsJsonAsync("api/Faq/insert", faq)).IsSuccessStatusCode;

        public async Task<bool> UpdateFaqAsync(FaqClass faq) =>
            (await _http.PostAsJsonAsync("api/Faq/update", faq)).IsSuccessStatusCode;

        public async Task<bool> DeleteFaqAsync(int id) =>
            (await _http.DeleteAsync($"api/Faq/delete/{id}")).IsSuccessStatusCode;

        public async Task<bool> IncrementViewCountAsync(int id) =>
            (await _http.PostAsJsonAsync("api/Faq/increment-view", id)).IsSuccessStatusCode;
    }

}
