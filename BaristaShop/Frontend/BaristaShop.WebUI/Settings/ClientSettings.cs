namespace BaristaShop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client BaristaShopVisitorClient { get; set; }
        public Client BaristaShopAdminClient { get; set; }
        public Client BaristaShopManagerClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
