using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Papasi.Areas.Cabin;
using Papasi.Data;
using Papasi.DataAccess;
using Papasi.DataAccess.Utils;
using Papasi.Entities;
using Papasi.Models;
using Papasi.Models.Mappings;
using Papasi.Services;
using Papasi.Theme;
using Papasi.Theme.libs;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
ConfigureLogging(builder.Logging, builder.Environment, builder.Configuration);
string password = args
   .DefaultIfEmpty("--password=")
   .Where(arg => arg.StartsWith("--password", ignoreCase: true, CultureInfo.InvariantCulture))
   .Select(arg => arg.Replace("--password=", string.Empty, ignoreCase: true, CultureInfo.InvariantCulture))
   .FirstOrDefault();
if (string.IsNullOrWhiteSpace(password))
{
    password = "M123@321#20r";
}
ConfigureServices(builder.Services, builder.Configuration, password);
var webApp = builder.Build();
ConfigureMiddlewares(webApp, webApp.Environment);
ConfigureEndpoints(webApp);
ConfigureDatabase(webApp);
webApp.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration, string password)
{
    services.AddOptions<AdminUserSeed>().Bind(configuration.GetSection("AdminUserSeed"));

    services.AddAutoMapper(typeof(MappingProfile).Assembly);

    var connectionString = configuration.GetConnectionString("DefaultConnection");

    // NOTE! this method of registering the db-context doesn't work with blazor-server apps!
    //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString))

    services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString.Replace("#password", password)));
    services.AddScoped(serviceProvider =>
                           serviceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
                                          .CreateDbContext());


    builder.Services.AddOptions<ProvidersURL>().Bind(configuration.GetSection("Providers"));
    builder.Services.AddOptions<CoinsURL>().Bind(configuration.GetSection("Coins"));
    builder.Services.AddOptions<ChainsInfoURL>().Bind(configuration.GetSection("ChainsInfo"));



    IConfiguration themeConfiguration = new ConfigurationBuilder()
                            .AddJsonFile("themesettings.json")
                            .Build();
    ThemeSettings.init(themeConfiguration);

    services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

    services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
    services.AddScoped<IUserInfoService, UserInfoService>();
    services.AddScoped<IProvidersService, ProvidersService>();
    services.AddScoped<IMarketService, MarketService>();


    services.AddScoped<IIdentityDbInitializer, IdentityDbInitializer>();

    services.AddSingleton<ITheme, Theme>();
    services.AddSingleton<IBootstrapBase, BootstrapBase>();


    services.AddRazorPages();
    services.AddServerSideBlazor();
}

void ConfigureLogging(ILoggingBuilder logging, IHostEnvironment env, IConfiguration configuration)
{
    logging.ClearProviders();

    logging.AddDebug();

    if (env.IsDevelopment())
    {
        logging.AddConsole();
    }

    logging.AddConfiguration(configuration.GetSection("Logging"));
}

void ConfigureMiddlewares(IApplicationBuilder app, IHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();
}

void ConfigureEndpoints(IApplicationBuilder app)
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages();
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
    });
}

void ConfigureDatabase(IApplicationBuilder app)
{
    app.ApplicationServices.MigrateDbContext<ApplicationDbContext>(
                                                                   scopedServiceProvider =>
                                                                       scopedServiceProvider
                                                                           .GetRequiredService<IIdentityDbInitializer>()
                                                                           .SeedDatabaseWithAdminUserAsync()
                                                                           .GetAwaiter()
                                                                           .GetResult()
                                                                  );
}