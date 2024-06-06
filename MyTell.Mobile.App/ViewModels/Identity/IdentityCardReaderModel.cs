using CommunityToolkit.Mvvm.Input;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;

namespace MyTell.Mobile.App.ViewModels.Identity
{
	public partial class IdentityCardReaderModel : ViewModelBase
	{
		public IdentityCardReaderModel(INavigationService navigationService) : base(navigationService)
		{
			
			
		}

		[RelayCommand]
		public async Task OpenScanner()
		{
			await Task.FromResult(0);
		}
	}
}
