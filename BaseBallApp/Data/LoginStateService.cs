using Microsoft.JSInterop;

namespace BaseBallApp.Data
{
    public class LoginStateService
    {
        private readonly IJSRuntime _js;
        public bool IsLoggedIn { get; private set; }
        public string? UserId { get; private set; }
        public string? UserName { get; private set; }
		public string? Role { get; private set; }  // 🔹 추가
		public DateTime? ExpireAt { get; private set; }

        public event Action? OnChange;

        public LoginStateService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitializeAsync()
        {
            UserId = await _js.InvokeAsync<string>("sessionStorage.getItem", "UserId");
            UserName = await _js.InvokeAsync<string>("sessionStorage.getItem", "UserName");
			Role = await _js.InvokeAsync<string>("sessionStorage.getItem", "Role"); // 🔹 추가
			var expireStr = await _js.InvokeAsync<string>("sessionStorage.getItem", "ExpireAt");

            if (!string.IsNullOrEmpty(UserId) && DateTime.TryParse(expireStr, out var expire))
            {
                if (DateTime.Now < expire)
                {
                    IsLoggedIn = true;
                    ExpireAt = expire;
                }
                else
                {
                    await LogoutAsync(); // 만료되었으면 로그아웃
                }
            }

            NotifyStateChanged();
        }

        public async Task LogoutAsync()
        {
            await _js.InvokeVoidAsync("sessionStorage.clear");
            IsLoggedIn = false;
            UserId = null;
            UserName = null;
			Role = null; // 🔹 추가
			ExpireAt = null;
            NotifyStateChanged();
        }

        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
