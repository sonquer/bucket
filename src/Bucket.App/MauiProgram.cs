using Bucket.App.Data;
using Bucket.Domain.Interfaces.Repositories;
using Bucket.Infrastructure.Repositories;
using Bucket.UseCases;
using Bucket.UseCases.Services;
using MediatR;
using Microsoft.Fast.Components.FluentUI;

namespace Bucket.App
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
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		    builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddSingleton<CurrentContextService>();
            builder.Services.AddScoped<IClusterRepository, ClusterRepository>();

            builder.Services.AddMediatR(UseCasesDependencyInjection.Assembly);

            builder.Services.AddFluentUIComponents();
            builder.Services.AddHttpClient();

            return builder.Build();
        }
    }
}