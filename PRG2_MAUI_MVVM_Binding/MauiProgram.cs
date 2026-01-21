using Microsoft.Extensions.Logging;
using PRG2_MAUI_MVVM_Binding.Services;
using PRG2_MAUI_MVVM_Binding.ViewModel;

namespace PRG2_MAUI_MVVM_Binding
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

            // IStudentStorageService injiceras automatiskt i StudentsViewModel konstruktor, och använder Singleton
            builder.Services.AddSingleton<IStudentStorageService, JsonStudentStorageService>();

            // Transient är inte helt nödvändig för enklare appar, men ser till att helt ny instans skapas varje gång beroendet efterfrågas (Dependency Inversion Principle (DIP) ur SOLID)
            builder.Services.AddTransient<StudentsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
