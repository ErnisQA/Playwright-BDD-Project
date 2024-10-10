
using Newtonsoft.Json;

namespace PlaywrightPractice.SettingBinder
{
    public class HRSaleSettingBinders
    {
        [JsonProperty("homepageUrl")]
        public string HomepageUrl { get; set; }

        [JsonProperty("testResults_Path")]
        public string TestResults_Path { get; set; }

    }
}
