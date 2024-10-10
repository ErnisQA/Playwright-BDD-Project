using Playwright.APITesting.Services;

namespace Playwright.Framework.StepDefinitions
{
    [Binding]
    public class DemoAPIServiceStepDefinitions
    {
        private ServiceDemo serviceDemo;
        public DemoAPIServiceStepDefinitions()
        {
            serviceDemo = new ServiceDemo();
        }

        [When("Send {string}")]
        public async Task WhenSend(string method)
        {
            try
            {
                if (method.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    await serviceDemo.GetUserInformationAPI();
                }
                else if (method.Equals("post", StringComparison.OrdinalIgnoreCase))
                {
                    await serviceDemo.CreateUserAPI();
                }
                else
                {
                    throw new Exception($"Unsupported method: {method}. Please use correct method to call API");
                }
            }
            catch (Exception ex)
            {
                // Log Exception if needed
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }


        [Then("Verify Status code is {string}")]
        public async Task ThenVerifyStatusCodeIs(string statusCode)
        {
            try
            {
                await serviceDemo.VerifyStatusCode(statusCode);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
