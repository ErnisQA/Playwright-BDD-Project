
using Newtonsoft.Json;

namespace PlaywrightPractice.DataSetting
{
    public class ServiceDemoBinders
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }
    }
}
