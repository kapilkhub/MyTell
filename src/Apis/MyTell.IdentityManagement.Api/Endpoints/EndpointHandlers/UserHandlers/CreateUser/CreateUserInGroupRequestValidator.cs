using CreateUser;
using FluentValidation;
using FluentValidation.Validators;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser
{
	public class CreateUserInGroupRequestValidator : AbstractValidator<CreateUserInGroupRequest>
	{
		public CreateUserInGroupRequestValidator()
		{
			RuleFor(x => x.Profile).NotEmpty();
			RuleFor(x => x.Profile.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
			RuleFor(x => x.Profile.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
			RuleFor(x => x.Profile.Login).NotEmpty().MinimumLength(5).MaximumLength(100);
			RuleFor(x => x.Profile.Email).NotEmpty().MinimumLength(5).MaximumLength(100)
				.EmailAddress(EmailValidationMode.AspNetCoreCompatible);
			RuleFor(x => x.GroupIds).NotNull()
									.Must(m => m.Any())
									.Must(m => !m.Exists(s => string.IsNullOrEmpty(s)));
		}
	}
}
