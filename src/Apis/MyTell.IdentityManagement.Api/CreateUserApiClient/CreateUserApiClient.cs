// Generated using Postman2CSharp https://postman2csharp.com/Convert
namespace CreateUser
{
	public class CreateUserApiClient : ICreateUserApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = string.Empty;
        private readonly string _apikey = string.Empty;
        public CreateUserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"https://{_url}/api/v1/users/");
    
            _httpClient.DefaultRequestHeaders.Add($"Authorization", $"SSWS {_apikey}");
        }
    
        public Task<CreateUserWithoutCredentialsResponse> CreateUserWithoutCredentials(CreateUserWithoutCredentialsParameters queryParameters, CreateUserWithoutCredentialsRequest request, CancellationToken cancellationToken = default)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"", parametersDict);
            return _httpClient.PostJsonAsync<CreateUserWithoutCredentialsResponse>(queryString, request, cancellationToken: cancellationToken);
        }
    
        public Task<CreateUserWithPasswordResponse> CreateUserWithPassword(CreateUserWithPasswordParameters queryParameters, CreateUserWithPasswordRequest request, CancellationToken cancellationToken = default)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"", parametersDict);
            return _httpClient.PostJsonAsync<CreateUserWithPasswordResponse>(queryString, request, cancellationToken: cancellationToken);
        }
    }
}