using MyTell.Mobile.App.Views.Identity;

namespace MyTell.Mobile.App
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(IdentityCardReaderPage), typeof(IdentityCardReaderPage));
			Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
		}
	}
}
