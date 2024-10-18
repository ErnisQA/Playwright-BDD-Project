
using Microsoft.Extensions.Configuration;
using PlaywrightPractice.DataSetting;
using PlaywrightPractice.SettingBinder;
using Serilog;

namespace PlaywrightPractice.Utilities
{
    public static class ConfigReader
    {
        public static void SetFrameworkSetting()
        {
            // Set Base Path for appsettings.json
            var configurationBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var logsConfiguration = new ConfigurationBuilder()
            .AddJsonFile("logsettings.json")
            .Build();

            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
           .ReadFrom.Configuration(logsConfiguration)
           .CreateLogger();

            IConfigurationRoot configurationRoot = configurationBuilder.Build();


            // Set Data from appsettings.json
            SetHRSaleSetting(configurationRoot);
            SetAccountDataSetting(configurationRoot);
            SetServiceDemoDataSetting(configurationRoot);
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
    }
}
