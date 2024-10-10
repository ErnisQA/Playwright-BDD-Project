
namespace Playwright.Framework.Page
{
    public class DemoQARegisterPage
    {
        private IPage _currentPage;
        public DemoQARegisterPage(HookContext hookContext)
        {
            _currentPage = hookContext.Page;
        }

        #region
        // DemoQA Page Locator
        private const string _firstName = "//input[@id ='firstName']";
        private const string _lastName = "//input[@id ='lastName']";
        private const string _email = "//input[@id ='userEmail']";
        private const string _gender = "//div[@id ='genterWrapper']//label[@for ='gender-radio-1']";
        private const string _mobileNumber = "//input[@id ='userNumber']";
        private const string _btnSubmit = "//button[@id ='submit']";
        private const string _successMessage = "//div[@id= 'example-modal-sizes-title-lg']";
        #endregion

        #region
        public async Task InputFirstName(string firstName)
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isFirstnameFieldVisible = await _currentPage.Locator(_firstName).IsVisibleAsync();
                    if (isFirstnameFieldVisible)
                    {
                        await _currentPage.Locator(_firstName).FillAsync(firstName);
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_lastName} not found after 60 seconds");
        }

        public async Task InputLastName(string lastName)
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isLastnameFieldVisible = await _currentPage.Locator(_lastName).IsVisibleAsync();
                    if (isLastnameFieldVisible)
                    {
                        await _currentPage.Locator(_lastName).FillAsync(lastName);
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_lastName} not found after 60 seconds");
        }

        public async Task InputEmail(string email)
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isEmailFieldVisible = await _currentPage.Locator(_email).IsVisibleAsync();
                    if (isEmailFieldVisible)
                    {
                        await _currentPage.Locator(_email).FillAsync(email);
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_email} not found after 60 seconds");
        }

        public async Task InputGender()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isGenderRadioButtonVisible = await _currentPage.Locator(_gender).IsVisibleAsync();
                    if (isGenderRadioButtonVisible)
                    {
                        await _currentPage.Locator(_gender).ClickAsync();
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_gender} not found after 60 seconds");
        }

        public async Task InputMobilephoneNumber(string mobileNumber)
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isMobilePhoneFieldVisible = await _currentPage.Locator(_mobileNumber).IsVisibleAsync();
                    if (isMobilePhoneFieldVisible)
                    {
                        await _currentPage.Locator(_mobileNumber).FillAsync(mobileNumber);
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_mobileNumber} not found after 60 seconds");
        }

        public async Task ClickSubmitButton()
        {
            DateTime maxTime = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < maxTime)
            {
                try
                {
                    bool isSubmitButtonVisible = await _currentPage.Locator(_btnSubmit).IsVisibleAsync();
                    if (isSubmitButtonVisible)
                    {
                        await _currentPage.Locator(_btnSubmit).ClickAsync();
                        return; // Exit the method after successfully click
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // If the loop completes without finding the input field, throw an exception
            throw new Exception($"{_btnSubmit} not found after 60 seconds");
        }

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

        public async Task RegisterUser(string firstName, string lastName, string email, string mobileNumber)
        {
            await InputFirstName(firstName);
            await InputLastName(lastName);
            await InputEmail(email);
            await InputGender();
            await InputMobilephoneNumber(mobileNumber);
        }

        #endregion
    }
}
