﻿using CommunityToolkit.Mvvm.Input;
using IdentityModel.OidcClient;
using Mopups.PreBaked.Services;
using MyTell.Mobile.App.Constants;
using MyTell.Mobile.App.Okta;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;
using UraniumUI.Dialogs.Mopups;

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
			
		 var loginResult =	await _preBakedMopupService.WrapReturnableTaskInLoader(
				_oktaClient.LoginAsync(),				
				Color.FromArgb(ColorConstaint.PrimaryColor), 
				Color.FromArgb(ColorConstaint.WhiteColor), 
				new List<string>([LoadingDisplayText.Loading, LoadingDisplayText.PleaseWait]),
				Color.FromArgb(ColorConstaint.PrimaryColor)
				);
			if (!loginResult.IsError)
			{
				await Shell.Current.DisplayAlert("Success", "Login Successful", "OK");
				//_preBakedMopupService.
				////_dialogService.
			}
			else
			{
				await Shell.Current.DisplayAlert("Error", loginResult.ErrorDescription, "Cancel");
				//await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
			}
		}


	}
}
