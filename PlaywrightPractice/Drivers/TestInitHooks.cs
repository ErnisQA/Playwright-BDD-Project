using Allure.Net.Commons;
using PlaywrightPractice.SettingBinder;
using PlaywrightPractice.Utilities;

namespace PlaywrightPractice.Support
{
    public class TestInitHooks
    {
        private const string videosFolder = "\\Videos";
        private AllureLifecycle allure = AllureLifecycle.Instance;
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

            // Initialize config to load appsettings.json
            InitializeSettingsConfig();

            // Set TestResults folder directory
            string testResultsDirectory = HRSaleSetting.HRSaleDataSetting.TestResults_Path;

            // Initialize record video
            var videoDirectory = testResultsDirectory + videosFolder;
            options.RecordVideoDir = videoDirectory;
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
