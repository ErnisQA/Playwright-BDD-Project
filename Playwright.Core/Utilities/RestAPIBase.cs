using RestSharp;

namespace Playwright.APITesting.Support
{
    public class RestAPIBase
    {
        private IRestClient _restClient;

        public RestAPIBase(IRestClient restClient)
        {
            _restClient = restClient;
        }


        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return await _restClient.ExecuteAsync(request);
        }

        public async Task<RestResponse> ExecuteGetAsync(RestRequest request)
        {
            return await _restClient.ExecuteGetAsync(request);
        }

        public async Task<RestResponse> ExecutePostAsync(RestRequest request)
        {
            return await _restClient.ExecutePostAsync(request);
        }

        public async Task<RestResponse> ExecuteDeleteAsync(RestRequest request)
        {
            return await _restClient.ExecuteDeleteAsync(request);
        }

    }
}
