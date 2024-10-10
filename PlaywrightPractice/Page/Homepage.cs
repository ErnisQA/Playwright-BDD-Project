
namespace PlaywrightPractice.Page
{
    public class Homepage
    {
        private IPage _currentPage;

        public Homepage(HookContext hookContext)
        {
            _currentPage = hookContext.Page;
        }

        #region
        //Locator
        private const string _successMessage = "//div/h2[contains(text(), 'Logged In Successfully.')]";
        private const string _usernameDisplay = "//ul//div/a/h6/p";
        private const string _btnLogout = "(//a/i)[1]";
        #endregion

        #region


        public async Task<string> VerifySuccessMessageDisplay()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isSuccessMessageVisible = await _currentPage.Locator(_successMessage).IsVisibleAsync();
                    if (isSuccessMessageVisible)
                    {
                        return await _currentPage.Locator(_successMessage).InnerTextAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_successMessage} not found after 60 seconds");
        }

        public async Task<string> VerifyUsernameDisplayInHomepage()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isUsernamInHomepageVisible = await _currentPage.Locator(_usernameDisplay).IsVisibleAsync();
                    if (isUsernamInHomepageVisible)
                    {
                        return await _currentPage.Locator(_usernameDisplay).InnerTextAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_usernameDisplay} not found after 60 seconds");
        }

        public async Task CLickLogoutButton()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isCLickLogoutButtonVisible = await _currentPage.Locator(_btnLogout).IsVisibleAsync();
                    if (isCLickLogoutButtonVisible)
                    {
                        await _currentPage.Locator(_btnLogout).ClickAsync();
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_btnLogout} not found after 60 seconds");
        }
        #endregion
    }
}
