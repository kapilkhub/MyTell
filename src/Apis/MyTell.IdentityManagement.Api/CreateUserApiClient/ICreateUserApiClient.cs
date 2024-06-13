using OneOf;
using System.IO;
using System.Threading.Tasks;
namespace CreateUser
{
    public interface ICreateUserApiClient
    {
		Task<OneOf<CreateUserInGroupOKResponse,CreateUserBadRequestResponse>> CreateUserInGroup(CreateUserInGroupParameters queryParameters, CreateUserInGroupRequest request, CancellationToken cancellationToken = default);
		Task<OneOf<CreateUserWithoutCredentialsOKResponse, CreateUserBadRequestResponse>> CreateUserWithoutCredentials(CreateUserWithoutCredentialsParameters queryParameters, CreateUserWithoutCredentialsRequest request, CancellationToken cancellationToken = default);
        Task<CreateUserWithPasswordResponse> CreateUserWithPassword(CreateUserWithPasswordParameters queryParameters, CreateUserWithPasswordRequest request, CancellationToken cancellationToken = default);
    }
}