
using BaristaShop.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace BaristaShop.WebUI.Services.CredentialTokenServices
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, 
            IMemoryCache memoryCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _memoryCache = memoryCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetCredentialToken()
        {
            if (_memoryCache.TryGetValue("baristashoptoken", out string cachedToken))
            {
                return cachedToken;
            }

            // eğer bellekten token gelmiyorsa, yeni bir token alınacak

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });


            // passwordTokenRequest ile benzer sadece şifre ve kullanıcı adı yok ve token visitor için alınıyor.
            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.BaristaShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.BaristaShopVisitorClient.ClientSecret,
                Address =discoveryEndPoint.TokenEndpoint
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

             _memoryCache.Set("baristashoptoken", newToken.AccessToken, TimeSpan.FromSeconds( newToken.ExpiresIn));

            return newToken.AccessToken;

        }
    }
}
