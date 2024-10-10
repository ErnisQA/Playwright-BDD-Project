using FluentAssertions;
using Playwright.Core.DataSetting;
using PlaywrightPractice.DataSetting;
using PlaywrightPractice.SettingBinder;

namespace PlaywrightPractice.StepDefinitions
{
    [Binding]
    public class LoginHRSaleStepDefinitions
    {
        private IPage _currentPage;
        private LoginPage _loginPage;
        private Homepage _homepage;
        private UserData _userData;

        public LoginHRSaleStepDefinitions(HookContext hookContext, UserData userData)
        {
            _currentPage = hookContext.Page;
            _loginPage = new LoginPage(hookContext);
            _homepage = new Homepage(hookContext);
            _userData = userData;
        }


        [Given("Navigate to {string}")]
        public async Task NavigateTo(string homePage)
        {

            if (homePage.Equals("hrsale", StringComparison.OrdinalIgnoreCase))
            {
                homePage = HRSaleSetting.HRSaleDataSetting.HomepageUrl;
            }
            else if (homePage.Equals("demoqa", StringComparison.OrdinalIgnoreCase))
            {
                homePage = DemoQASetting.DemoQADataSetting.HomepageUrl;
            }
            else
            {
                throw new Exception("Your Homepage is not found, please check again");
            }

            await _currentPage.GotoAsync(homePage);

        }


        [When("Input with following Username and Password")]
        public async Task InputWithFollowingUsernameAndPassword(DataTable dataTable)
        {
            // Maping Gherkin table to model 
            var userAccount = dataTable.CreateInstance<UserData>();
            string username = string.Empty;
            string password = string.Empty;

            // Reset UsernameForCheck and PasswordForCheck for check another cases
            _userData.UsernameForCheck = string.Empty;
            _userData.PasswordForCheck = string.Empty;

            switch (userAccount.Username.ToLowerInvariant())
            {
                case "super admin":
                    // In case, Ghekin has Username and Password, assign fully Username and Password
                    if (!String.IsNullOrEmpty(userAccount.Password))
                    {
                        username = AccountSetting.AccountDataSetting.SuperAdmin_Username;
                        password = AccountSetting.AccountDataSetting.SuperAdmin_Username;
                        // Assign username and password to verify 
                        _userData.UsernameForCheck = username;
                        _userData.PasswordForCheck = password;
                        break;
                    }
                    // In case, Gherkin missing Password, assign only Username
                    username = AccountSetting.AccountDataSetting.SuperAdmin_Username;
                    // Assign only username to verify
                    _userData.UsernameForCheck = username;
                    break;

                case "employee":
                    if (!String.IsNullOrEmpty(userAccount.Password))
                    {
                        username = AccountSetting.AccountDataSetting.Employee_Username;
                        password = AccountSetting.AccountDataSetting.Employee_Password;
                        _userData.UsernameForCheck = username;
                        _userData.PasswordForCheck = password;
                        break;
                    }
                    username = AccountSetting.AccountDataSetting.Employee_Username;
                    _userData.UsernameForCheck = username;
                    break;

                case "client":
                    if (!String.IsNullOrEmpty(userAccount.Password))
                    {
                        username = AccountSetting.AccountDataSetting.Client_Username;
                        password = AccountSetting.AccountDataSetting.Client_Password;
                        _userData.UsernameForCheck = username;
                        _userData.PasswordForCheck = password;
                        break;
                    }
                    username = AccountSetting.AccountDataSetting.Client_Username;
                    _userData.UsernameForCheck = username;
                    break;

                case "":
                    password = AccountSetting.AccountDataSetting.Client_Password;
                    _userData.PasswordForCheck = password;
                    break;

                default:
                    throw new Exception($"Exception: Username and Password are blank");
            }

            await _loginPage.LoginWithCredentialsInformation(username, password);
        }


        [Then("Verify User login successfully with message {string}")]
        public async Task VerifyUserLoginSuccessfullyWithMessage(string expectedMessage)
        {
            try
            {
                string actualMessage = await _homepage.VerifySuccessMessageDisplay();
                actualMessage.Should().Be(expectedMessage, $"Expected message is '{expectedMessage}', but got '{actualMessage}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while verifying the success message: {ex.Message}", ex);
            }

        }


        [Then("Verify Username {string} is displayed in Homepage")]
        public void VerifyUsernameIsDisplayedInHomepage(string username)
        {
            _homepage.VerifyUsernameDisplayInHomepage().Should().Be(username);
        }

        [Then("Click Logout button")]
        public async Task ThenClickLogoutButton()
        {
            await _homepage.CLickLogoutButton();
        }

        [Then("Verify User login unsuccessfully with message {string}")]
        public async Task VerifyUserLoginUnsuccessfullyWithMessage(string expectedMessage)
        {
            string actualMessage = String.Empty;
            // In case, missing Username in Ghekin, it will verify "Missing Username" message
            if (string.IsNullOrEmpty(_userData.UsernameForCheck))
            {
                try
                {
                    if (String.IsNullOrEmpty(actualMessage))
                    {
                        await _loginPage.ClickLoginButton();
                        actualMessage = await _loginPage.VerifyMissingUsernameMessageDisplay();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error occurred while verifying the success message: {ex.Message}", ex);
                }
            }
            // In case, missing Password in Gherkin, it will verify "Missing Username" message
            else if (string.IsNullOrEmpty(_userData.PasswordForCheck))
            {
                try
                {
                    if (String.IsNullOrEmpty(actualMessage))
                    {
                        await _loginPage.ClickLoginButton();
                        actualMessage = await _loginPage.VerifyMissingPasswordMessageDisplay();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error occurred while verifying the success message: {ex.Message}", ex);
                }
                // Verify Error Message display after click Login button
                actualMessage.Should().Be(expectedMessage, $"Expected message is '{expectedMessage}', but got '{actualMessage}'.");
            }
            else
            {
                throw new Exception("Both Username and Password are blank, Unsuccessful Login.");
            }
        }
    }
}
