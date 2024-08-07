using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListWasm;
using TodoListWasm.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BackendConnection"]) });
builder.Services.AddTransient<ITaskClientService, TaskClientService>();
builder.Services.AddTransient<IUserClientService, UserClientService>();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
