using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class AppSettingsManager
    {
        public string ClientUrl { get; set; }
        public AppSettingsManager(IConfiguration configuration)
        {
            ClientUrl = configuration.GetValue<string>(nameof(ClientUrl));
        }
    }
}
