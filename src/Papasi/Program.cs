using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.Connections;
using Papasi.Data;
using Papasi.Models;
using Papasi.Models.Mappings;
using Papasi.Theme;
using Papasi.Theme.libs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ITheme, Theme>();
builder.Services.AddSingleton<IBootstrapBase, BootstrapBase>();


IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json")
							.Build();
builder.Services.AddOptions<AdminUserSeed>().Bind(configuration.GetSection("AdminUserSeed"));

builder.Services.AddOptions<Providers>().Bind(configuration.GetSection("Providers"));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
var connectionString = configuration.GetConnectionString("DefaultConnection");


IConfiguration themeConfiguration = new ConfigurationBuilder()
							.AddJsonFile("themesettings.json")
							.Build();
ThemeSettings.init(themeConfiguration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub(configureOptions: options =>
{
	options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
});

app.MapFallbackToPage("/_Host");

app.Run();
