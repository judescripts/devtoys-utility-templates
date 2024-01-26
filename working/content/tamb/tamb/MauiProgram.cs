using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TAMB.Data;

namespace TAMB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("TAMB.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream!).Build();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });
            builder.Configuration.AddConfiguration(config);
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddMauiBlazorWebView();

            // TODO: Update or remove this section depending on your needs
            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton<AuthenticationStateProvider, ExternalAuthStateProvider>();
            builder.Services.AddCascadingAuthenticationState();


#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
