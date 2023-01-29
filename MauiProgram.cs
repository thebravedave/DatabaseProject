using Microsoft.Extensions.Logging;
using DatabaseProject.ViewModels;
using DatabaseProject.Views;
using DatabaseProject.Database;

namespace DatabaseProject;

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

		//Add ViewModel Dependency Injection Configurations
		builder.Services.AddSingleton<HomeViewModel>();


		//Add Views Dependency Injection
		builder.Services.AddSingleton<HomePage>();


		//Add Data Access Object Injection
		builder.Services.AddSingleton<IStudentDataAccess, StudentDataAccess>();	
		builder.Services.AddSingleton<IClassDataAccess, ClassDataAccess>();


#if DEBUG


		builder.Logging.AddDebug();

#endif


		return builder.Build();
	}
}

