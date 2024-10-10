
using Newtonsoft.Json;

namespace PlaywrightPractice.DataSetting
{
    public class AccountSettingBinders
    {
        [JsonProperty("superAdmin_Username")]
        public string SuperAdmin_Username { get; set; }

        [JsonProperty("superAdmin_Password")]
        public string SuperAdmin_Password { get; set; }

        [JsonProperty("employee_Username")]
        public string Employee_Username { get; set; }

        [JsonProperty("employee_Password")]
        public string Employee_Password { get; set; }

        [JsonProperty("client_Username")]
        public string Client_Username { get; set; }

        [JsonProperty("client_Password")]
        public string Client_Password { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("MobileNumber")]
        public string MobileNumber { get; set; }


    }
}
