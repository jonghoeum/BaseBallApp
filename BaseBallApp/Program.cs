using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BaseBallApp;
using BaseBallApp.Data;
using BaseBallApp.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// appsettings.json �ε�
var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var options = await http.GetFromJsonAsync<ApiOptions>("appsettings.json");
builder.Services.AddSingleton(options);

// HttpClient ���
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri(options?.ApiBaseUrl ?? "https://localhost:7067/")
});
//builder.Services.AddScoped(sp => new HttpClient
//{
//	BaseAddress = new Uri("https://localhost:7067/") // BaseBallApp.API ���� �ּ�
//});

//builder.Services.AddSingleton<DataService>();
builder.Services.AddScoped<TrophyService>();
await builder.Build().RunAsync();
