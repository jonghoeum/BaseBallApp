using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BaseBallApp;
using BaseBallApp.Data;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddSingleton<DataService>();
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri("https://localhost:7067/") // BaseBallApp.API 실행 주소
});

//builder.Services.AddSingleton<DataService>();
builder.Services.AddScoped<DataService>();
await builder.Build().RunAsync();
