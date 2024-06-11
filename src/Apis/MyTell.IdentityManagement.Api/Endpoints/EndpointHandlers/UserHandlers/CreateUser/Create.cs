using CreateUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser
{
    public static partial class User
    {
        public static async Task<Ok<CreateUserWithoutCredentialsResponse>> Create(
            [FromBody] CreateUserWithoutCredentialsRequest request,
            [AsParameters] CreateUserWithoutCredentialsParameters queryParameters,
            [FromServices] ICreateUserApiClient createUserApiClient
          )
        {
            return TypedResults.Ok(await createUserApiClient.CreateUserWithoutCredentials(queryParameters, request));
        }
    }
}
