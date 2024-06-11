using MyTell.Mobile.App.ViewModels.Base;

namespace MyTell.Mobile.App.Views
{
	public abstract class ContentPageBase : ContentPage
	{
		public ContentPageBase()
		{
			NavigationPage.SetBackButtonTitle(this, string.Empty);
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (BindingContext is not IViewModelBase ivmb)
			{
				return;
			}

			await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
		}
	}
}
