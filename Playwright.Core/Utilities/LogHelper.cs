using log4net;
namespace Playwright.Framework.Utilities
{
    public static class LogHelper
    {
        public static ILog GetLogger<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }
    }
}
