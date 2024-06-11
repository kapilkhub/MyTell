﻿using CommunityToolkit.Mvvm.ComponentModel;
using MyTell.Mobile.App.Entities;
using MyTell.Mobile.App.Enums;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace MyTell.Mobile.App.ViewModels.Identity
{
	[QueryProperty(nameof(IdentityCardReadEntity), nameof(IdentityCardReadEntity))]
	public partial class RegistrationViewModel : ViewModelBase, IQueryAttributable
	{
		[ObservableProperty]
		private IdentityCardReadEntity? _identityCardReadEntity;

		[ObservableProperty]
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		[NotifyDataErrorInfo]
		private string _firstName = default!;

		[ObservableProperty]
		[MinLength(3)]
		[MaxLength(100)]
		[NotifyDataErrorInfo]
		private string _middleName = default!;

		[ObservableProperty]
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		[NotifyDataErrorInfo]
		private string _lastName = default!;

		[ObservableProperty]
		[Required]
		[MinLength(15)]
		[MaxLength(15)]
		[NotifyDataErrorInfo]
		private string _emiratesId = default!;

		[ObservableProperty]
		[Required]
		[NotifyDataErrorInfo]
		private DateOnly _dateOfBirth = default!;

		[ObservableProperty]
		[Required]
		[NotifyDataErrorInfo]
		private Gender _gender = default!;


		[ObservableProperty]
		[Required]
		[EmailAddress]
		[MinLength(5)]
		[NotifyDataErrorInfo]
		private string _email = default!;

		[ObservableProperty]
		[Required]
		[EmailAddress]
		[MinLength(5)]
		[NotifyDataErrorInfo]
		private string _confirmedEmail = default!;

		[ObservableProperty]
		[Required]
		[MinLength(12)]
		[MaxLength(30)]
		[NotifyDataErrorInfo]
		private string _password = default!;

		[ObservableProperty]
		[Required]
		[MinLength(12)]
		[MaxLength(30)]
		[NotifyDataErrorInfo]
		private string _confirmPassword = default!;

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
		public override async Task InitializeAsync()
		{
			await IsBusyFor(async () =>
			{
				Email = "kk.jecrc@gmail.com";
				await Task.FromResult(0);
			});
		}
	}
}