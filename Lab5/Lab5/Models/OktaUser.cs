using Newtonsoft.Json;

namespace Lab5.Models
{
    public class OktaUser
    {
        public Profile Profile { get; set; }
    }

    public class Profile
    {
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
