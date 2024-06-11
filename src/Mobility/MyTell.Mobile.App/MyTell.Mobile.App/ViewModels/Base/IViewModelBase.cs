using CommunityToolkit.Mvvm.Input;
using MyTell.Mobile.App.Services;

namespace MyTell.Mobile.App.ViewModels.Base
{
	public interface IViewModelBase
    {
		public INavigationService NavigationService { get; }

		public IAsyncRelayCommand InitializeAsyncCommand { get; }

		public bool IsBusy { get; }

		public bool IsInitialized { get; }

		Task InitializeAsync();
	}
}
