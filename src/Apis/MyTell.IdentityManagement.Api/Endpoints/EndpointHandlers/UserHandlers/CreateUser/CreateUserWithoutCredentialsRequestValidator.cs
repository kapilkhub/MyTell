using CreateUser;
using FluentValidation;
using FluentValidation.Validators;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser
{
    public class CreateUserWithoutCredentialsRequestValidator : AbstractValidator<CreateUserWithoutCredentialsRequest>
    {
        public CreateUserWithoutCredentialsRequestValidator()
        {
            RuleFor(x => x.Profile).NotEmpty();
            RuleFor(x => x.Profile.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Profile.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Profile.Login).NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(x => x.Profile.Email).NotEmpty().MinimumLength(5).MaximumLength(100)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
