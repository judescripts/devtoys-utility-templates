using Microsoft.Extensions.Logging;

namespace MyTamb
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MyTamb.appsettings.json");
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



            return builder.Build();
        }
    }
}
