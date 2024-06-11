using System.IO;
using System.Threading.Tasks;
namespace CreateUser
{
    public interface ICreateUserApiClient
    {
        Task<CreateUserWithoutCredentialsResponse> CreateUserWithoutCredentials(CreateUserWithoutCredentialsParameters queryParameters, CreateUserWithoutCredentialsRequest request, CancellationToken cancellationToken = default);
        Task<CreateUserWithPasswordResponse> CreateUserWithPassword(CreateUserWithPasswordParameters queryParameters, CreateUserWithPasswordRequest request, CancellationToken cancellationToken = default);
    }
}