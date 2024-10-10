using PlaywrightPractice.SettingBinder;
using PlaywrightPractice.Utilities;

namespace PlaywrightPractice.Support
{
    public class TestInitHooks
    {
        public TestInitHooks()
        {

        }

        public static async Task InitializeBrowser(IPlaywright playwright, HookContext hookContext, BrowserNewContextOptions options, ScenarioContext scenarioContext)
        {

            playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            // Setting Browser
            BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new[] { "--start-fullscreen" }
            };

            // Add ScreenSize (If needed)
            //options.ScreenSize = new ScreenSize
            //{

            //};

            // Initialize config reader to read appsetting.json 
            InitializeSettingsConfig();

            // Initialize record video
            var currentDirectory = HRSaleSetting.HRSaleDataSetting.TestResults_Path;
            options.RecordVideoDir = $"{currentDirectory}/videos/";
            options.RecordVideoSize = new RecordVideoSize() { Width = 1280, Height = 720 };
            options.StrictSelectors = false;

            // Initialize Browser
            hookContext.Browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions).WaitAsync(TimeSpan.FromSeconds(10));
            hookContext.BrowserContext = await hookContext.Browser.NewContextAsync(options);
            hookContext.Page = await hookContext.BrowserContext.NewPageAsync();
        }

        public static void InitializeSettingsConfig()
        {
            ConfigReader.SetFrameworkSetting();
        }
    }
}
