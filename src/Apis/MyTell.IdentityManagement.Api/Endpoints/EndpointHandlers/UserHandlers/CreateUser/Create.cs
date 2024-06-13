using CreateUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser
{
	public static partial class User
    {
        public static async Task<Results<Ok<CreateUserWithoutCredentialsOKResponse>,BadRequest<CreateUserBadRequestResponse>>> CreateUserWithoutCredentials(
            [FromBody] CreateUserWithoutCredentialsRequest request,
            [AsParameters] CreateUserWithoutCredentialsParameters queryParameters,
            [FromServices] ICreateUserApiClient createUserApiClient
          )
        {
            var result = await createUserApiClient.CreateUserWithoutCredentials(queryParameters, request);
			if (result.IsT0) 
			{
				return TypedResults.Ok(result.AsT0);
			}
            else
            {
				return TypedResults.BadRequest(result.AsT1);
			}
        }

		public static async Task<Results<Ok<CreateUserInGroupOKResponse>, BadRequest<CreateUserBadRequestResponse>>> CreateUserInGroup(
			[FromBody] CreateUserInGroupRequest request,
			[AsParameters] CreateUserInGroupParameters queryParameters,
			[FromServices] ICreateUserApiClient createUserApiClient
		  )
		{
			var result = await createUserApiClient.CreateUserInGroup(queryParameters, request);
			if (result.IsT0)
			{
				return TypedResults.Ok(result.AsT0);
			}
			else
			{
				return TypedResults.BadRequest(result.AsT1);
			}
		}

		public static async Task<Ok<CreateUserWithPasswordResponse>> CreateUserWithPassword(
		  [FromBody] CreateUserWithPasswordRequest request,
		  [AsParameters] CreateUserWithPasswordParameters queryParameters,
		  [FromServices] ICreateUserApiClient createUserApiClient
		)
		{
			return TypedResults.Ok(await createUserApiClient.CreateUserWithPassword(queryParameters, request));
		}
	}
}
