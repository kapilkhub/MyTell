using CommunityToolkit.Mvvm.Input;
using MyTell.Mobile.App.Okta;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;

namespace MyTell.Mobile.App.ViewModels
{
	public partial class LoginViewModel : ViewModelBase
	{
		private readonly OktaClient _oktaClient;
		public LoginViewModel(INavigationService navigationService, OktaClient oktaClient)
			: base(navigationService)
		{
			_oktaClient = oktaClient;
		}

		[RelayCommand]
		public async Task Login()
		{
			await _oktaClient.LoginAsync();
		}

       
    }
}
