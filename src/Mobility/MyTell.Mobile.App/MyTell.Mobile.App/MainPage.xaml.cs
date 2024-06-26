﻿using MyTell.Mobile.App.ViewModels;
using MyTell.Mobile.App.Views;
using System.Diagnostics;

namespace MyTell.Mobile.App
{
	public partial class MainPage : ContentPageBase
	{
		
		private bool _animate;

		public MainPage(LoginViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
			
		}

		
		protected override async void OnAppearing()
		{
			var content = Content;
			Content = null;
			Content = content;
			await AnimateIn();
			
		}

		protected override void OnDisappearing()
		{
			_animate = false;
		}

		public async Task AnimateIn()
		{
			if (DeviceInfo.Platform == DevicePlatform.WinUI)
			{
				return;
			}

			await AnimateItem(Banner, 10500);
		}

		private async Task AnimateItem(View uiElement, uint duration)
		{
			try
			{
				while (_animate)
				{
					await uiElement.ScaleTo(1.05, duration, Easing.SinInOut);
					await Task.WhenAll(
						uiElement.FadeTo(1, duration, Easing.SinInOut),
						uiElement.LayoutTo(new Rect(new Point(0, 0), new Size(uiElement.Width, uiElement.Height))),
						uiElement.FadeTo(.9, duration, Easing.SinInOut),
						uiElement.ScaleTo(1.15, duration, Easing.SinInOut)
					);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	}
}