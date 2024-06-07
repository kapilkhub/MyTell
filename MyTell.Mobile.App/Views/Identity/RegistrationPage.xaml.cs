using MyTell.Mobile.App.ViewModels.Identity;

namespace MyTell.Mobile.App.Views.Identity;


public partial class RegistrationPage : ContentPageBase
{
	
	public RegistrationPage(RegistrationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}