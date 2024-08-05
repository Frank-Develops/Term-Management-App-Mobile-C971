using C971.DB;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using C971.Models;

namespace C971
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "terms.db");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<TermData>(s, dbPath));

            string dbPath2 = Path.Combine(FileSystem.AppDataDirectory, "courses.db");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CourseData>(s, dbPath2));

            string dbPath3 = Path.Combine(FileSystem.AppDataDirectory, "assessments.db");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<AssessmentData>(s, dbPath3));

           

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
