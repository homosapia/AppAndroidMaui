using MauiApp1.Interfase;
using MauiApp1.Services;
using Microsoft.Extensions.Logging;
using testKyzia;

namespace MauiApp1
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
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ITreeBuilderServices, TreeBuilderServices>(); 
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
