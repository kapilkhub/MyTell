using CommunityToolkit.Mvvm.Input;
using MyTell.Mobile.App.Entities;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;
using Plugin.Maui.OCR;
using System.Globalization;

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
					var cardReader = new IdentityCardReadEntity();

					var names = ocrResult.Lines.FirstOrDefault(l => l.StartsWith("name", StringComparison.OrdinalIgnoreCase))?.Split(":");
					cardReader.Name = names?.Length > 1 ? names[1]?.Trim() : null;

					var nationalities = ocrResult.Lines.FirstOrDefault(l => l.StartsWith("nationality", StringComparison.OrdinalIgnoreCase))?.Split(":");
					cardReader.Nationality = nationalities?.Length > 1 ? nationalities[1]?.Trim() : null;

					cardReader.EmiratesId = ocrResult.Lines.FirstOrDefault(l => l.StartsWith("784", StringComparison.OrdinalIgnoreCase));

					await NavigationService.GoToRegister(cardReader);

				}
				else
				{
					await Shell.Current.DisplayAlert("Error", "Ocr Not Possible", "OK");
				}
			}
		}
	}
}
