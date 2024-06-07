using CommunityToolkit.Mvvm.ComponentModel;
using MyTell.Mobile.App.Entities;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;

namespace MyTell.Mobile.App.ViewModels.Identity
{
	[QueryProperty(nameof(IdentityCardReadEntity), nameof(IdentityCardReadEntity))]
	public partial class RegistrationViewModel : ViewModelBase, IQueryAttributable
	{
		[ObservableProperty]
		private IdentityCardReadEntity? _identityCardReadEntity;
		public RegistrationViewModel(INavigationService navigationService)
			: base(navigationService)
		{
		}

		public override void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			if (query.ContainsKey(nameof(IdentityCardReadEntity)))
			{
				Shell.Current.DisplayAlert("Data", "is present", "ok");
			}
		}
	}
}
