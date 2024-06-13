using CreateUser;
using MyTell.IdentityManagement.Api.Endpoints.EndpointFilters;
using MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointRouteBuilderExtensions
{
	public static class UserEndpointExtension
    {
        public static void RegisterUserCreateEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var userEndpoint = endpointRouteBuilder.MapGroup("/user").WithOpenApi();

            userEndpoint.MapPost("", User.CreateUserWithoutCredentials)
                .AddEndpointFilter<ValidationFilter<CreateUserWithoutCredentialsRequest>>()
				.ProducesValidationProblem(400)
				.Produces(422,typeof(CreateUserWithoutCredentialsBadRequestResponse))
				.Produces(200, typeof(CreateUserWithoutCredentialsOKResponse))
				.ProducesValidationProblem(400)
				.WithSummary("Creates user without password")
                .WithDescription("Creates user without password and Activation status");

			userEndpoint.MapPost("/password", User.CreateUserWithPassword)
			  .AddEndpointFilter<ValidationFilter<CreateUserWithPasswordRequest>>()
			  .ProducesValidationProblem(400)
			  .WithSummary("Creates user with password")
			  .WithDescription("Creates user with password and Activation status");
		}
    }
}
