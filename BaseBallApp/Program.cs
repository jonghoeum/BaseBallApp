using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BaseBallApp;
using BaseBallApp.Data;
using BaseBallApp.Models;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// appsettings.json을 불러오기 위해 HttpClient 임시 생성
using var tempClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

// appsettings.json을 읽어서 ApiSettings 정보를 가져옴
var configJson = await tempClient.GetFromJsonAsync<Dictionary<string, Dictionary<string, string>>>("appsettings.json");
var apiBaseAddress = configJson?["ApiSettings"]["BaseAddress"] ?? throw new Exception("BaseAddress not found in appsettings.json");

// DI에 HttpClient 등록
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri(apiBaseAddress)
});
//builder.Services.AddScoped(sp => new HttpClient
//{
//	BaseAddress = new Uri("https://localhost:7067/") // BaseBallApp.API 실행 주소
//});

//builder.Services.AddSingleton<DataService>();
builder.Services.AddScoped<TrophyService>();
await builder.Build().RunAsync();
