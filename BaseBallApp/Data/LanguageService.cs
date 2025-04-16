using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MetisHomePage.Data
{
    public class LanguageService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action OnChange;

        private string _currentCulture = "ko"; // 기본값 한국어
        public string CurrentCulture => _currentCulture;

        public LanguageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            var savedCulture = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "CurrentCulture");
            if (!string.IsNullOrEmpty(savedCulture))
            {
                _currentCulture = savedCulture;
                NotifyStateChanged();
            }
        }

        public async Task SetCurrentCulture(string language)
        {
            if (_currentCulture != language)
            {
                _currentCulture = language;
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "CurrentCulture", language);
                await _jsRuntime.InvokeVoidAsync("ToggleLanguage", language); // JS에 상태 변경 전달
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
