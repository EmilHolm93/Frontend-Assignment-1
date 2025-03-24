using CarWorkshop.Data;
using CarWorkshop.Viewmodels;
using CarWorkshop.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace CarWorkshop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "carworkshop.db");

            builder.Services.AddSingleton(new Database(dbPath));
            
            builder.Services.AddSingleton<WorkordersViewModel>();
            builder.Services.AddTransient<WorkordersViewModel>();
            builder.Services.AddTransient<BookingPage>();
            builder.Services.AddTransient<CalenderViewModel>();
            builder.Services.AddTransient<CalenderPage>();
            builder.Services.AddTransient<InvoicePage>();
            builder.Services.AddTransient<InvoiceViewModel>();


            return builder.Build();
        }
    }
}