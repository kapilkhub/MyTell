using CommunityToolkit.Mvvm.Input;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;
using Plugin.Maui.OCR;

namespace MyTell.Mobile.App.ViewModels.Identity
{
	public partial class IdentityCardReaderModel : ViewModelBase
	{
		private readonly IOcrService _ocrService;

		public IdentityCardReaderModel(INavigationService navigationService, IOcrService ocrService)
			: base(navigationService)
		{
			_ocrService = ocrService;
		}

		public override async Task InitializeAsync()
		{

			await IsBusyFor(async () =>
			{
				await _ocrService.InitAsync();
			});
		}

		[RelayCommand]
		public async Task OpenScanner()
		{
			var pickResult = await MediaPicker.Default.CapturePhotoAsync();
			if (pickResult != null)
			{
				using var imageAsStream = await pickResult.OpenReadAsync();
				var imageAsBytes = new byte[imageAsStream.Length];
				await imageAsStream.ReadAsync(imageAsBytes);

				var ocrResult = await OcrPlugin.Default.RecognizeTextAsync(imageAsBytes);
				if (ocrResult.Success)
				{
					await Shell.Current.DisplayAlert("Success", ocrResult.AllText, "OK");
				}
				else 
				{
					await Shell.Current.DisplayAlert("Error", "Ocr Not Possible", "OK");
				}
			}
		}
	}
}
