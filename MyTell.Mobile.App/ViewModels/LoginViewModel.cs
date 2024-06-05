using CommunityToolkit.Mvvm.Input;
using Mopups.PreBaked.Services;
using MyTell.Mobile.App.Okta;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;

namespace MyTell.Mobile.App.ViewModels
{
	public partial class LoginViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly OktaClient _oktaClient;
		private readonly PreBakedMopupService _preBakedMopupService;
		

		public LoginViewModel(INavigationService navigationService, OktaClient oktaClient, PreBakedMopupService preBakedMopupService)
			: base(navigationService)
		{
			_navigationService = navigationService;
			_oktaClient = oktaClient;
			_preBakedMopupService = preBakedMopupService;
		}

		[RelayCommand]
		public async Task Login()
		{
			
			await _preBakedMopupService.WrapTaskInLoader(
				Task.Delay(10000), 
				Color.FromArgb("#f03224"), 
				Color.FromArgb("#FFFFFF"), 
				new List<string>(["Loading","We are logging you in."]),
				Color.FromArgb("#f03224")
				);


			//var loginResult = await _oktaClient.LoginAsync();

			//if (!loginResult.IsError)
			//{
			//	//_dialogService.
			//}
			//else
			//{
			//	//await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
			//}
		}


	}
}
