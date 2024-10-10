namespace PlaywrightPractice.Page
{
    public class LoginPage
    {
        private ScenarioContext _scenarioContext;
        private ScenarioStepContext _stepContext;
        private IPage _currentPage;
        public LoginPage(HookContext hookContext)
        {
            _currentPage = hookContext.Page;
        }


        #region
        // Login Page
        private const string _usernameInput = "//div/div//input[@id= 'iusername']";
        private const string _passwordInput = "//div/div//input[@id= 'ipassword']";
        private const string _btnCLickLogin = "//div/div/div//button//span[contains(text(), 'Login')]";
        private const string _msgErrorPassword = "//div[@id='toast-container']/div/div[contains(text(), 'The password field is required.')]";
        private const string _msgErrorUsername = "//div[@id='toast-container']/div/div[contains(text(), 'The username field is required.')]";
        #endregion


        #region
        // Method

        public async Task InputUsername(string username)
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isUsernameFieldVisible = await _currentPage.Locator(_usernameInput).IsVisibleAsync();
                    if (isUsernameFieldVisible)
                    {
                        await _currentPage.Locator(_usernameInput).FillAsync(username);
                        return; // Exit the method after successfully filling the username
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    Console.WriteLine(ex.Message);
                }

            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_usernameInput} not found after 60 seconds");
        }

        public async Task InputPassword(string password)
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isPasswordFieldVisible = await _currentPage.Locator(_passwordInput).IsVisibleAsync();
                    if (isPasswordFieldVisible)
                    {
                        await _currentPage.Locator(_passwordInput).FillAsync(password);
                        return; // Exit the method after successfully filling the password
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    Console.WriteLine(ex.Message);
                }

            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_passwordInput} not found after 60 seconds");
        }


        public async Task ClickLoginButton()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isCLicklButtonVisible = await _currentPage.Locator(_btnCLickLogin).IsVisibleAsync();
                    if (isCLicklButtonVisible)
                    {
                        await _currentPage.Locator(_btnCLickLogin).ClickAsync();
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    Console.WriteLine(ex.Message);
                }

            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_btnCLickLogin} not found after 60 seconds");
        }

        public async Task LoginWithCredentialsInformation(string username, string password)
        {
            await InputUsername(username);
            await InputPassword(password);
            await ClickLoginButton();
        }

        public async Task<string> VerifyMissingPasswordMessageDisplay()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isMissingPasswordVisible = await _currentPage.Locator(_msgErrorPassword).IsVisibleAsync();
                    if (isMissingPasswordVisible)
                    {
                        return await _currentPage.Locator(_msgErrorPassword).InnerTextAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_msgErrorPassword} not found after 60 seconds");
        }

        public async Task<string> VerifyMissingUsernameMessageDisplay()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isMissingUsernameVisible = await _currentPage.Locator(_msgErrorUsername).IsVisibleAsync();
                    if (isMissingUsernameVisible)
                    {
                        return await _currentPage.Locator(_msgErrorUsername).InnerTextAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if needed 
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_msgErrorUsername} not found after 60 seconds");
        }
        #endregion
    }
}
