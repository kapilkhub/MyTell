using OneOf;
using System.Net;

// Generated using Postman2CSharp https://postman2csharp.com/Convert
namespace CreateUser
{
	public class CreateUserApiClient : ICreateUserApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "dev-12536842.okta.com";
        private readonly string _apikey = "00YX2SAhOtZfW7ZsfwH_tyN6TsF3_TjQgnlkWrcvdc";
        public CreateUserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"https://{_url}/api/v1/users/");
    
            _httpClient.DefaultRequestHeaders.Add($"Authorization", $"SSWS {_apikey}");
        }
    
        public async Task<OneOf<CreateUserWithoutCredentialsOKResponse, CreateUserWithoutCredentialsBadRequestResponse>> CreateUserWithoutCredentials(CreateUserWithoutCredentialsParameters queryParameters, CreateUserWithoutCredentialsRequest request, CancellationToken cancellationToken = default)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"", parametersDict);
            var response = await _httpClient.PostAsJsonAsync(queryString, request, cancellationToken: cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadJsonAsync<CreateUserWithoutCredentialsOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await response.ReadJsonAsync<CreateUserWithoutCredentialsBadRequestResponse>();
            }
            throw new Exception($"CreateUserWithoutCredentials: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        public Task<CreateUserWithPasswordResponse> CreateUserWithPassword(CreateUserWithPasswordParameters queryParameters, CreateUserWithPasswordRequest request, CancellationToken cancellationToken = default)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"", parametersDict);
            return _httpClient.PostJsonAsync<CreateUserWithPasswordResponse>(queryString, request, cancellationToken: cancellationToken);
        }
    }
}