using CommunityToolkit.Maui;
using InputKit.Handlers;
using Microsoft.Extensions.Configuration;
using Mopups.Hosting;
using Mopups.PreBaked.Services;
using Mopups.Services;
using MyTell.Mobile.App.Clients.IdentityManagement;
using MyTell.Mobile.App.Okta;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels;
using MyTell.Mobile.App.ViewModels.Identity;
using MyTell.Mobile.App.Views.Identity;
using Plugin.Maui.OCR;
using System.Reflection;
using UraniumUI;

namespace MyTell.Mobile.App
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder.AddAppSettings();

			builder
				.UseMauiApp<App>()
				.ConfigureMauiHandlers(handlers =>
				{
					handlers.AddInputKitHandlers();
				})
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
				.RegisterPages()
				.RegisterViewModels()
				.RegisterServices()
				.RegisterHttpClient();

		


			var oktaClientConfiguration = new OktaClientConfiguration()
			{
				// Use "https://{yourOktaDomain}/oauth2/default" for the "default" authorization server, or
				// "https://{yourOktaDomain}/oauth2/<MyCustomAuthorizationServerId>"

				OktaDomain = builder.Configuration.GetSection("OKTA").GetValue<string>("AUTHORIZATION_SERVER")!,
				ClientId = builder.Configuration.GetSection("OKTA").GetValue<string>("CLIENT_ID")!,
				RedirectUri = "myapp://callback",
				Browser = new WebBrowserAuthenticator()
			};

			builder.Services.AddSingleton(new OktaClient(oktaClientConfiguration));
			return builder.Build();
		}


		private static void AddAppSettings(this MauiAppBuilder builder)
		{
			builder.AddJsonSettings("MyTell.Mobile.App.appsettings.json");
#if DEBUG
			builder.AddJsonSettings("MyTell.Mobile.App.appsettings.development.json");
#endif

#if !DEBUG
         builder.AddJsonSettings("MyTell.Mobile.app.appsettings.production.json");
#endif

		}

		private static void AddJsonSettings(this MauiAppBuilder builder, string filename)
		{
			using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename);

			if (stream is not null)
			{
				var config = new ConfigurationBuilder()
							.AddJsonStream(stream)
							.Build();


				builder.Configuration.AddConfiguration(config);
			}


		}

		private static MauiAppBuilder RegisterHttpClient(this MauiAppBuilder builder)
		{
			builder.Services.AddHttpClient<IIdentityManagementClient, IdentityManagementClient>(options => 
			             options.BaseAddress = new Uri(builder.Configuration.GetSection("IDENTITY_CLIENT").GetValue<string>("BASE_URL")!));
			return builder;
		}

		private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddTransient<IdentityCardReaderPage>();
			builder.Services.AddTransient<RegistrationPage>();
			return builder;
		}
		private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
		{
			builder.Services.AddMopupsDialogs();
			builder.Services.AddSingleton(OcrPlugin.Default);
			builder.Services.AddSingleton<INavigationService, NavigationService>();
			builder.Services.AddSingleton(MopupService.Instance);
			builder.Services.AddSingleton(PreBakedMopupService.GetInstance());
			return builder;
		}

		private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<LoginViewModel>();
			builder.Services.AddTransient<IdentityCardReaderModel>();
			builder.Services.AddTransient<RegistrationViewModel>();
			return builder;
		}
	}
}
