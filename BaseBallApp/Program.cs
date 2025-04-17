using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BaseBallApp;
using BaseBallApp.Data;
using BaseBallApp.Models;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// appsettings.json�� �ҷ����� ���� HttpClient �ӽ� ����
using var tempClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

// appsettings.json�� �о ApiSettings ������ ������
var configJson = await tempClient.GetFromJsonAsync<Dictionary<string, Dictionary<string, string>>>("appsettings.json");
var apiBaseAddress = configJson?["ApiSettings"]["BaseAddress"] ?? throw new Exception("BaseAddress not found in appsettings.json");

// DI�� HttpClient ���
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri(apiBaseAddress)
});
//builder.Services.AddScoped(sp => new HttpClient
//{
//	BaseAddress = new Uri("https://localhost:7067/") // BaseBallApp.API ���� �ּ�
//});

//builder.Services.AddSingleton<DataService>();
builder.Services.AddScoped<TrophyService>();
await builder.Build().RunAsync();
