using CreateUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyTell.IdentityManagement.Api.EndpointHandlers
{
	public static class UserHandlers
	{
		public static async Task<Ok<CreateUserWithoutCredentialsResponse>> CreateUser(
			[FromBody] CreateUserWithoutCredentialsRequest request,
			[AsParameters] CreateUserWithoutCredentialsParameters queryParameters,
			[FromServices] ICreateUserApiClient createUserApiClient
		  )
		{
			return TypedResults.Ok(await createUserApiClient.CreateUserWithoutCredentials(queryParameters, request));
		}
	}
}

