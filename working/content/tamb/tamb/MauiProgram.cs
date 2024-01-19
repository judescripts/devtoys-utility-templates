using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace tamb
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("tamb.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream!).Build();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });
            builder.Configuration.AddConfiguration(config);

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton<AuthenticationStateProvider, ExternalAuthStateProvider>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}