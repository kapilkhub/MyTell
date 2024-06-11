using MyTell.Mobile.App.Entities;
using MyTell.Mobile.App.Views.Identity;

namespace MyTell.Mobile.App.Services
{
	public class NavigationService : INavigationService
	{
		public async Task GoToIdentityCardReader() => await Shell.Current.GoToAsync(nameof(IdentityCardReaderPage));

		public async Task GoToRegister(IdentityCardReadEntity dict) =>
            await Shell.Current.GoToAsync(nameof(RegistrationPage), new Dictionary<string, object>
			{
				[nameof(IdentityCardReadEntity)] = dict
			});

	}
}
