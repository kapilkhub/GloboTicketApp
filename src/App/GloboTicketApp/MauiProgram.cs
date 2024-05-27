using CommunityToolkit.Maui;
using GloboTicketApp.Repositories;
using GloboTicketApp.Services;
using GloboTicketApp.ViewModels;
using GloboTicketApp.Views;
using Microsoft.Extensions.Logging;

namespace GloboTicketApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.RegisterRepositories()
				.RegisterServices()
				.RegisterViewModels()
				.RegisterViews()
				.RegisterNavigationServices();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}

		private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
		{
			var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
		  ? "http://10.0.2.2:5191"
		  : "https://localhost:7185";

			builder.Services.AddTransient<IEventRepository, EventRepository>();
			builder.Services.AddHttpClient("GloboTicketAdminApiClient", client =>
			{
				client.BaseAddress = new Uri(baseUrl);
				client.DefaultRequestHeaders.Add("Accept", "application/json");
			});

			return builder;
		}

		private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
		{
			builder.Services.AddTransient<IEventService, EventService>();
			return builder;
		}

		private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<EventListOverviewViewModel>();
			builder.Services.AddTransient<EventDetailViewModel>();
			builder.Services.AddTransient<EventAddEditViewModel>();
			return builder;
		}

		private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
		{
			builder.Services.AddTransient<EventDetailPage>();
			builder.Services.AddTransient<EventAddEditPage>();
			builder.Services.AddSingleton<EventOverviewPage>();

			return builder;
		}

		private static MauiAppBuilder RegisterNavigationServices(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<INavigationService, NavigationService>();
			return builder;
		}
	}
}
