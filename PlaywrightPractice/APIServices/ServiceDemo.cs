
using FluentAssertions;
using Playwright.APITesting.Support;
using Playwright.Framework.Models;
using RestSharp;
using System.Net;

namespace Playwright.APITesting.Services
{
    public class ServiceDemo
    {
        private RestAPIBase _restAPIBase;
        private ServiceDemoSetting _setting;
        private RestResponse response;

        public ServiceDemo()
        {

            _setting = new ServiceDemoSetting();

            _restAPIBase = new RestAPIBase(_setting.RestClient);
        }

        public async Task GetUserInformationAPI()
        {
            // Initialize a response variable to store the result
            response = null;

            // Create a new GET request
            _setting.Request = new RestRequest($"/users/2", Method.Get);

            // Add the "Content-Type" header to the request
            _setting.Request.AddHeader("Content-Type", "application/json");

            // Set a maximum time limit of 3 minutes to execute the request
            DateTime maxTime = DateTime.Now.AddMinutes(3);

            while (DateTime.Now < maxTime)
            {
                // Execute request using RestAPIBase
                response = await _restAPIBase.ExecuteGetAsync(_setting.Request);

                // If a valid response is received and the status code is 200, exit the loop
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    break;
                }

                throw new Exception("The request did not succeed after 3 minutes");
            }
        }
        public async Task CreateUserAPI()
        {
            // Initialize a response variable to store the result
            response = null;

            // Create a new GET request
            // If use ExecutePostAsync, you can remove Method.Post below (or do not need to change)
            _setting.Request = new RestRequest($"/users", Method.Post);

            // Add the "Content-Type" header to the request
            _setting.Request.AddHeader("Content-Type", "application/json");

            // Add body using Model
            var body = new ServiceDemoRequestModel
            {
                Name = "ErnisQA" + DateTime.Now.ToFileTimeUtc(),
                Job = "Automation Test"
            };

            _setting.Request.AddJsonBody(body);

            // Set a maximum time limit of 3 minutes to execute the request
            DateTime maxTime = DateTime.Now.AddMinutes(3);

            while (DateTime.Now < maxTime)
            {
                // Execute request using RestAPIBase
                response = await _restAPIBase.ExecutePostAsync(_setting.Request);

                // If a valid response is received and the status code is 201, exit the loop
                if (response != null && response.StatusCode == HttpStatusCode.Created)
                {
                    break;
                }

                throw new Exception("The request did not succeed after 3 minutes.");
            }
        }
        public async Task VerifyStatusCode(string statusCode)
        {
            try
            {
                // Parse the status code string to an HttpStatusCode enum
                var expectedStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCode);

                // Assert that the response status code matches the expected status code
                response.StatusCode.Should().Be(expectedStatusCode);
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
