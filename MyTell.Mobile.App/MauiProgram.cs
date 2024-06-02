using Mopups.Hosting;
using MyTell.Mobile.App.Okta;
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
				.ConfigureMopups()
				.UseUraniumUI()
				.UseUraniumUIMaterial()
				.UseUraniumUIBlurs()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
					fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
					fonts.AddFont("Montserrat-Bold.ttf", "Montserrat-Bold");
					fonts.AddFont("Montserrat-Regular.ttf", "Montserrat-Regular");
					fonts.AddFont("SourceSansPro-Regular.ttf", "SourceSansPro-Regular");
					fonts.AddFont("SourceSansPro-Solid.ttf", "SourceSansPro-Solid");

					fonts.AddMaterialSymbolsFonts();
				});

			builder.Services.AddMopupsDialogs();
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
	}
}
