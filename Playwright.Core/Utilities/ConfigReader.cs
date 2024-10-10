
using Microsoft.Extensions.Configuration;
using Playwright.Core.DataSetting;
using PlaywrightPractice.DataSetting;
using PlaywrightPractice.SettingBinder;

namespace PlaywrightPractice.Utilities
{
    public static class ConfigReader
    {
        public static void SetFrameworkSetting()
        {
            // Set Base Path
            var configurationBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();


            SetHRSaleSetting(configurationRoot);
            SetAccountDataSetting(configurationRoot);
            SetServiceDemoDataSetting(configurationRoot);
            SetDemoQASetting(configurationRoot);
        }

        public static void SetHRSaleSetting(IConfigurationRoot configurationRoot)
        {
            var data = configurationRoot.GetSection("HRSaleSetting").Get<HRSaleSettingBinders>();
            if (data != null)
            {
                HRSaleSetting.HRSaleDataSetting = data;
            }
        }

        public static void SetAccountDataSetting(IConfigurationRoot configurationRoot)
        {
            var data = configurationRoot.GetSection("AccountSetting").Get<AccountSettingBinders>();
            if (data != null)
            {
                AccountSetting.AccountDataSetting = data;
            }
        }

        public static void SetServiceDemoDataSetting(IConfigurationRoot configurationRoot)
        {
            var data = configurationRoot.GetSection("ServiceDemo").Get<ServiceDemoBinders>();
            if (data != null)
            {
                ServiceDemoDataSetting.ServiceDemoDataSettings = data;
            }
        }

        // Set Data for DemoQA Page
        public static void SetDemoQASetting(IConfigurationRoot configurationRoot)
        {
            var data = configurationRoot.GetSection("DemoQASetting").Get<DemoQASettingBinders>();
            if (data != null)
            {
                DemoQASetting.DemoQADataSetting = data;
            }
        }
    }
}
