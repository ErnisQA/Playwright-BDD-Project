
namespace PlaywrightPractice.Support
{
    public class HookContext
    {
        public IPage Page { get; set; }

        public IBrowser Browser { get; set; }

        public IBrowserContext BrowserContext { get; set; }
    }
}
