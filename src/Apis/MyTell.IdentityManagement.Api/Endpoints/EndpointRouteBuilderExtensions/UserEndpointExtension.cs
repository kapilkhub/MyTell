using CreateUser;
using MyTell.IdentityManagement.Api.Endpoints.EndpointFilters;
using MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointRouteBuilderExtensions
{
	public static class UserEndpointExtension
    {
        public static void RegisterUserCreateEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var romanEndPoints = endpointRouteBuilder.MapGroup("/user").WithOpenApi();

            romanEndPoints.MapPost("", User.Create)
                .AddEndpointFilter<ValidationFilter<CreateUserWithoutCredentialsRequest>>()
				.ProducesValidationProblem(400)
                .WithSummary("Creates user without password")
                .WithDescription("Creates user without password and Activation status");
        }
    }
}
