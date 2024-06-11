using MyTell.Mobile.App.ViewModels.Identity;

namespace MyTell.Mobile.App.Views.Identity;

public partial class IdentityCardReaderPage : ContentPageBase
{
	public IdentityCardReaderPage(IdentityCardReaderModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}