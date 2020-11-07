using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class AppSettingsManager : IAppSettingsManager
    {
        public string ClientUrl { get; set; }
        public string DataApiUrl { get; set; }
        public AppSettingsManager(IConfiguration configuration)
        {
            ClientUrl = configuration.GetValue<string>(nameof(ClientUrl));
            DataApiUrl = configuration.GetValue<string>(nameof(DataApiUrl));
        }
    }
}
