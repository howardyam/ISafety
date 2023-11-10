using Microsoft.Extensions.Logging;
using ISafety.View;

namespace ISafety;

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

		//View Registration
		builder.Services.AddSingleton<StudentListPage>();

		// View Moedles
		
#if DEBUG
		builder.Logging.AddDebug();
#endif
		

		return builder.Build();
	}
}
