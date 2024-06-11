using MyTell.IdentityManagement.Api.EndpointHandlers;

namespace MyTell.IdentityManagement.Api.EndPointRouteBuilderExtensions
{
	public static class UserEndpointExtension
	{
		public static void RegisterUserCreateEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
		{
			var romanEndPoints = endpointRouteBuilder.MapGroup("/user");

			romanEndPoints.MapPost("", UserHandlers.CreateUser);
		}
	}
}
