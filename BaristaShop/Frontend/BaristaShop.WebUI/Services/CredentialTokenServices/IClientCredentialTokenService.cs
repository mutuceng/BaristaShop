namespace BaristaShop.WebUI.Services.CredentialTokenServices
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetCredentialToken();
    }
}
