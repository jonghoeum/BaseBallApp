using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BaseBallApp;
using BaseBallApp.Data;
using BaseBallApp.Models;
using System.Net.Http.Json;

using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;

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
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<GalleryService>();
builder.Services.AddScoped<NoticeService>();
builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<RecruitService>();
builder.Services.AddScoped<SupporterService>();
builder.Services.AddScoped<FaqService>();
builder.Services.AddScoped<LoginStateService>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons()
    .AddBlazoriseRichTextEdit();

await builder.Build().RunAsync();
