global using BlazorCRUD.Client.Services.ClienteServices;
global using BlazorCRUD.Client.Services.InmuebleServices;
global using BlazorCRUD.Client.Services.TipoInmuebleServices;
global using BlazorCRUD.Client.Services.CondicionServices;
global using BlazorCRUD.Client.Services.FormaPagoServices;
global using BlazorCRUD.Shared;
using BlazorCRUD.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IInmuebleServices, InmuebleServices>();
builder.Services.AddScoped<ITipoInmuebleServices, TipoInmuebleServices>();
builder.Services.AddScoped<ICondicionServices, CondicionServices>();
builder.Services.AddScoped<IFormaPagoServices, FormaPagoServices>();

await builder.Build().RunAsync();
