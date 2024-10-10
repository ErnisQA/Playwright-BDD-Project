using PlaywrightPractice.DataSetting;
using RestSharp;

namespace Playwright.APITesting.Services
{
    public class ServiceDemoSetting
    {
        public RestRequest Request { get; set; }
        public RestClient RestClient { get; set; }
        public ServiceDemoSetting()
        {
            RestClient = new RestClient(ServiceDemoDataSetting.ServiceDemoDataSettings.BaseUrl);
        }

    }
}
