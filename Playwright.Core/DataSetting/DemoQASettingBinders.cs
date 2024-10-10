using Newtonsoft.Json;

namespace Playwright.Core.DataSetting
{
    public class DemoQASettingBinders
    {
        [JsonProperty("homepageUrl")]
        public string HomepageUrl { get; set; }
    }
}
