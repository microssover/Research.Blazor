using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Research.Blazor.UI;
using Research.Blazor.UI.Base;
using Research.Blazor.UI.DI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.RegisterServices();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<MainLayoutCascadingValue>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7232/api/") });

await builder.Build().RunAsync();

