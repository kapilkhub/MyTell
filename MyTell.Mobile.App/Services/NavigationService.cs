using MyTell.Mobile.App.Views.Identity;

namespace MyTell.Mobile.App.Services
{
	public class NavigationService  : INavigationService
    {
        public async Task GoToIdentityCardReader() => await Shell.Current.GoToAsync(nameof(IdentityCardReaderPage));
    }
}
