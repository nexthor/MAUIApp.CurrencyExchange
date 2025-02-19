using MAUIApp.CurrencyExchange.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MAUIApp.CurrencyExchange
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MAUIApp.CurrencyExchange.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream!)
                        .Build();

            builder.Configuration.AddConfiguration(config);
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddTransient<CurrencyConverterPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
