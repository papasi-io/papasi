using Papasi.Data;
using Papasi.Theme;
using Papasi.Theme.libs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
	.AddHubOptions(options =>
	{
		options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
		options.HandshakeTimeout = TimeSpan.FromSeconds(30);
	});

builder.Services.AddHttpClient();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ITheme, Theme>();
builder.Services.AddSingleton<IBootstrapBase, BootstrapBase>();

IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("themesettings.json")
							.Build();

var app = builder.Build();

ThemeSettings.init(configuration);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
