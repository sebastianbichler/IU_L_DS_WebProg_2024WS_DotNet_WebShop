using FrontendRCL;
using FrontendRCL.Components;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Radzen;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFrontendRCLServiceDI(builder.Configuration);

builder.Services.AddRadzenComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("ApiHttpClient", client => { client.BaseAddress = new Uri("https://localhost:7221"); });

await builder.Build().RunAsync();


