using MyTell.Mobile.App.Entities;
using MyTell.Mobile.App.Views.Identity;

namespace MyTell.Mobile.App.Services
{
	public interface INavigationService
	{
		Task GoToIdentityCardReader();
		Task GoToRegister(IdentityCardReadEntity dict);
	}
}
