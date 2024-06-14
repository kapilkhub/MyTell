using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyTell.Mobile.App.Clients.IdentityManagement;
using MyTell.Mobile.App.Entities;
using MyTell.Mobile.App.Enums;
using MyTell.Mobile.App.Services;
using MyTell.Mobile.App.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyTell.Mobile.App.ViewModels.Identity
{
	[QueryProperty(nameof(IdentityCardReadEntity), nameof(IdentityCardReadEntity))]
	public partial class RegistrationViewModel : ViewModelBase, IQueryAttributable, IDisposable
	{
		
		[ObservableProperty]
		private IdentityCardReadEntity? _identityCardReadEntity;

		[ObservableProperty]
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		[NotifyDataErrorInfo]
		private string? _firstName = default;

		[ObservableProperty]
		[MinLength(3)]
		[MaxLength(100)]
		[NotifyDataErrorInfo]
		private string? _middleName = default!;

		[ObservableProperty]
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		[NotifyDataErrorInfo]
		private string? _lastName = default!;

		[ObservableProperty]
		[Required]
		[MinLength(15)]
		[MaxLength(15)]
		[NotifyDataErrorInfo]
		private string? _emiratesId = default!;

		[ObservableProperty]
		[Required]
		[NotifyDataErrorInfo]
		private DateOnly? _dateOfBirth = default!;

		[ObservableProperty]
		[Required]
		[NotifyDataErrorInfo]
		private Gender? _gender = default!;


		[ObservableProperty]
		[Required]
		[EmailAddress]
		[MinLength(5)]
		[NotifyDataErrorInfo]
		[NotifyPropertyChangedFor(nameof(ConfirmedEmail))]
		private string _email = default!;

		[ObservableProperty]
		[Required]
		[EmailAddress]
		[MinLength(5)]
		[NotifyPropertyChangedFor(nameof(Email))]
		[NotifyDataErrorInfo]
		[CustomValidation(typeof(IdentityCardReadEntity), nameof(ValidateConfirmEmail))]
		private string _confirmedEmail = default!;

		private IdentityCardReadEntity? cardReader = default!;

		public ValidationResult? ValidateConfirmEmail(string confirmedEmail, ValidationContext context)
		{

			if (confirmedEmail != Email)
			{
				return new("Email does not match");
			}

			return ValidationResult.Success;
		}

		public ObservableCollection<ValidationResult> Errors { get; } = new();

		[RelayCommand(CanExecute = nameof(CanNext))]
		private async Task Next()
		{
			ValidateAllProperties();
			if (Errors.Any())
			{
				return;
			}
		}

		private bool CanNext()
		{
			return !HasErrors;
		}

		public RegistrationViewModel(INavigationService navigationService)
			: base(navigationService)
		{
			
			ErrorsChanged += RegistrationViewModel_ErrorsChanged;
		}

		private void RegistrationViewModel_ErrorsChanged(object? sender, System.ComponentModel.DataErrorsChangedEventArgs e)
		{
			Errors.Clear();
			GetErrors().ToList().ForEach(Errors.Add);
			NextCommand.NotifyCanExecuteChanged();
		}

		public override void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			if (query.ContainsKey(nameof(IdentityCardReadEntity)))
			{
				cardReader = query[nameof(IdentityCardReadEntity)] as IdentityCardReadEntity;
				
			}
		}
		public override async Task InitializeAsync()
		{
			await IsBusyFor(async () =>
			{
				if (cardReader is not null)
				{
					FirstName = cardReader.Name;
					EmiratesId = cardReader.EmiratesId;
					Gender = cardReader.Gender;
				}
				await Task.FromResult(0);
			});
		}

		public void Dispose()
		{
			ErrorsChanged -= RegistrationViewModel_ErrorsChanged;
		}
	}
}
