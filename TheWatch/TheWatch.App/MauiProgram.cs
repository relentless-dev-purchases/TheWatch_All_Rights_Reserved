
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using TheWatch.Shared;
using TheWatch.Shared.OpenAPI;



namespace TheWatch.App
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A maui program. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public static class MauiProgram
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates maui application. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <returns>   The new maui application. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
               
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("TheWatch.App.appsettings.json");

            builder.Configuration.AddConfiguration(new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build());

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
        builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif
            App.Settings = builder.Configuration.GetSection("TheWatch.App").Get<Settings>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(App.Settings.Url) });
            builder.Services.AddScoped(sp => new AppServices(App.Settings.Url, new HttpClient()));

            return builder.Build();
        }
    }
   
}