using FluentAssertions;
using Playwright.Framework.Page;
using PlaywrightPractice.DataSetting;

namespace Playwright.Framework.StepDefinitions
{
    [Binding]
    public class DemoQARegisterStepDefinitions
    {
        private IPage _currentPage;
        private LoginPage _loginPage;
        private Homepage _homepage;
        private UserData _userData;
        private DemoQARegisterPage _demoQARegisterPage;

        public DemoQARegisterStepDefinitions(HookContext hookContext, UserData userData)
        {
            _currentPage = hookContext.Page;
            _loginPage = new LoginPage(hookContext);
            _homepage = new Homepage(hookContext);
            _demoQARegisterPage = new DemoQARegisterPage(hookContext);
            _userData = userData;
        }


        [When("Input the following field for register user")]
        public async Task InputTheFollowingFieldForRegisterUser(DataTable dataTable)
        {

            try
            {
                // Declare and Assign value for user information
                var userAccount = dataTable.CreateInstance<UserData>();
                var firstName = string.Empty;
                var lastName = string.Empty;
                var email = string.Empty;
                var mobilePhone = string.Empty;

                firstName = AccountSetting.AccountDataSetting.FirstName;
                lastName = AccountSetting.AccountDataSetting.LastName;
                email = AccountSetting.AccountDataSetting.Email;
                mobilePhone = AccountSetting.AccountDataSetting.MobileNumber;

                await _demoQARegisterPage.RegisterUser(firstName, lastName, email, mobilePhone);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while verifying the success message: {ex.Message}", ex);
            }
        }


        [When("Click Submit button")]
        public async Task ClickSubmitButton()
        {
            try
            {
                await _demoQARegisterPage.ClickSubmitButton();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while verifying the success message: {ex.Message}", ex);
            }
        }


        [Then("Verify {string} message is displayed")]
        public async Task VerifyMessageIsDisplayed(string expectedMessage)
        {

            try
            {
                string actualMessage = await _demoQARegisterPage.VerifySuccessMessageDisplay();
                actualMessage.Should().Be(expectedMessage, $"Expected message is '{expectedMessage}', but got '{actualMessage}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while verifying the success message: {ex.Message}", ex);
            }
        }
    }
}
