using Microsoft.Extensions.Configuration;

namespace MyTell.Mobile.App.Clients.IdentityManagement
{
	public partial class IdentityManagementClient
	{
        public IdentityManagementClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
			_baseUrl = _httpClient.BaseAddress!.ToString();
        }

		
	}
}
