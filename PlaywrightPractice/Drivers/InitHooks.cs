
using Allure.Net.Commons;
using PlaywrightPractice.SettingBinder;
using Serilog;
using System.Text.RegularExpressions;

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
        private AllureLifecycle allure = AllureLifecycle.Instance;
        private string testcaseName;
        private string testResultsDirectory;
        private const string screenshotFolder = "\\Screenshot";
        private const string logsFolder = "\\Logs";

        public InitHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            testcaseName = GetTestcaseName();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            var stepText = ScenarioStepContext.Current.StepInfo.Text;
            var status = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            Log.Information($"Executing step: {stepText}");
        }


        [AfterStep]
        public void AfterStep()
        {
            var stepText = ScenarioStepContext.Current.StepInfo.Text;
            var stepStatus = ScenarioStepContext.Current.Status;
            if (_scenarioContext.TestError != null)
            {
                Log.Error($"Failed at: {stepText}");
                Log.Error($"Error: {_scenarioContext.TestError.Message}");
                Log.Error($"Step Status: {stepStatus}");
            }
            else
            {
                Log.Information($"Passed: {stepText}");
                Log.Information($"Step Status: {stepStatus}");
            }
        }

        [BeforeScenario]
        public async Task Initialize(ScenarioContext scenarioContext, HookContext context)
        {
            _context = context;
            _scenarioContext = scenarioContext;

            // Initialize Browser
            await InitializeBrowser(playwright, _context, options, _scenarioContext);

            // Read TestResults directory
            testResultsDirectory = HRSaleSetting.HRSaleDataSetting.TestResults_Path;

            // Write logs
            Log.Information($"==========================================================================");
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo.Title;
            Log.Information($"{testcaseName} -- {scenarioInfo}");
        }



        [AfterScenario]
        public async Task CleanUp(HookContext context)
        {
            _currentPage = context.Page;

            // Initialize Screenshot
            var screenshotDirectory = testResultsDirectory + screenshotFolder;

            // Capture Screenshot
            await _currentPage.ScreenshotAsync(new()
            {
                Path = $"{screenshotDirectory}/{testcaseName}.png",
                FullPage = true,
            });

            // Write logs:
            var scenarioInfo = ScenarioContext.Current.ScenarioInfo.Title;
            var scenarioStatus = ScenarioContext.Current.ScenarioExecutionStatus;
            if (_scenarioContext.TestError != null)
            {

                Log.Error($"Scenario failed: {_scenarioContext.ScenarioInfo.Title}");
                Log.Error($"Error: {_scenarioContext.TestError.Message}");
                Log.Error($"Status: {scenarioStatus}");
            }
            else
            {
                Log.Information($"Scenario Passed: {_scenarioContext.ScenarioInfo.Title}");
                Log.Information($"Status: {scenarioStatus}");
            }

            // CLose Browser
            await context.Browser.CloseAsync();

            // Close Logs
            await Log.CloseAndFlushAsync();

            // Add Screenshot into Allure Report
            AllureApi.AddAttachment(
                $"{testcaseName}.png",
                "image/png",
                File.ReadAllBytes($"{screenshotDirectory}/{testcaseName}.png")
            );

        }

        public string GetTestcaseName()
        {
            var tag = _scenarioContext.ScenarioInfo.Tags;
            string testcasePattern = @"^TC.*";

            var testcaseTags = tag.Where(tag => Regex.IsMatch(tag, testcasePattern)).FirstOrDefault();

            return testcaseTags;
        }
    }
}
