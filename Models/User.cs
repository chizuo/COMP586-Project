using System.ComponentModel;
namespace Registration.Models
{
    public class User
    {
        [DisplayName("Enter your id")]
        public string id { get; set; }
        [DisplayName("Enter your password")]
        public string password { get; set; }
    }
}