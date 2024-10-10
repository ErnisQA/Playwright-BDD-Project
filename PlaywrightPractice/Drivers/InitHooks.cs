
using PlaywrightPractice.SettingBinder;

namespace PlaywrightPractice.Support
{
    [Binding]
    public class InitHooks : TestInitHooks
    {
        public HookContext _context;
        private ScenarioContext _scenarioContext;
        private static BrowserNewContextOptions options = new();
        public IPage _currentPage;
        public static IPlaywright playwright;

        public InitHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task Initialize(ScenarioContext scenarioContext, HookContext context)
        {
            _context = context;
            _scenarioContext = scenarioContext;

            // Initialize Browser
            await InitializeBrowser(playwright, _context, options, _scenarioContext);
        }

        [AfterScenario]
        public async Task CleanUp(HookContext context)
        {
            _currentPage = context.Page;

            // Initialize Screenshot
            var currentDirectory = HRSaleSetting.HRSaleDataSetting.TestResults_Path;
            var screenshotName = $"screenshot" + DateTime.Now.ToFileTimeUtc();
            await _currentPage.ScreenshotAsync(new()
            {
                Path = $"{currentDirectory}/{screenshotName}.png",
                FullPage = true,
            });

            // CLose Browser
            await context.Browser.CloseAsync();
        }
    }
}
