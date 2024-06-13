using CreateUser;
using FluentValidation.Validators;
using FluentValidation;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser
{
	public class CreateUserWithPasswordRequestValidator : AbstractValidator<CreateUserWithPasswordRequest>
	{
		public CreateUserWithPasswordRequestValidator()
		{
			RuleFor(x => x.Profile).NotEmpty();
			RuleFor(x => x.Profile.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
			RuleFor(x => x.Profile.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
			RuleFor(x => x.Profile.Login).NotEmpty().MinimumLength(5).MaximumLength(100);
			RuleFor(x => x.Profile.Email).NotEmpty().MinimumLength(5).MaximumLength(100)
				.EmailAddress(EmailValidationMode.AspNetCoreCompatible);
			RuleFor(x => x.Credentials).NotEmpty();
			RuleFor(x => x.Credentials.Password).NotEmpty();

			RuleFor(x => x.Credentials.Password.Value).NotEmpty().MinimumLength(12).MaximumLength(30);
			RuleFor(x => x.Credentials.Password.Status).Empty();
			RuleFor(x => x.Credentials.Password.Type).Empty();
		}
	}
}
