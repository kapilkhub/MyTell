using CommunityToolkit.Maui;
using Mopups.Hosting;
using Mopups.PreBaked.Services;
using Mopups.Services;
using MyTell.Mobile.App.Okta;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels;
using Plugin.Maui.OCR;
using UraniumUI;

namespace MyTell.Mobile.App
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseOcr()
				.UseMauiCommunityToolkit()
				.UseUraniumUI()
				.UseUraniumUIMaterial()
				.UseUraniumUIBlurs()
				.ConfigureMopups()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIconsRegular");
					fonts.AddMaterialSymbolsFonts();
				})
				.RegisterViewModels()
				.RegisterServices();

			builder.Services.AddMopupsDialogs();
			builder.Services.AddSingleton(OcrPlugin.Default);
			builder.Services.AddSingleton<MainPage>();

			var oktaClientConfiguration = new Okta.OktaClientConfiguration()
			{
				// Use "https://{yourOktaDomain}/oauth2/default" for the "default" authorization server, or
				// "https://{yourOktaDomain}/oauth2/<MyCustomAuthorizationServerId>"

				OktaDomain = "https://dev-12536842.okta.com/oauth2/default",

				ClientId = "0oahfr6v3snTzUwOF5d7",
				RedirectUri = "myapp://callback",
				Browser = new WebBrowserAuthenticator()
			};

			builder.Services.AddSingleton(new OktaClient(oktaClientConfiguration));
			return builder.Build();
		}

		private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<INavigationService, NavigationService>();
			builder.Services.AddSingleton(MopupService.Instance);
			builder.Services.AddSingleton(PreBakedMopupService.GetInstance());
			return builder;
		}

		private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<LoginViewModel>();
			return builder;
		}
	}
}
