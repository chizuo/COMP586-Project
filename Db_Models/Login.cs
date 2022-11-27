using System.ComponentModel;
namespace Registration.Db_Models
{
    public class Login
    {
        [DisplayName("Enter your id")]
        public string id { get; set; }
        [DisplayName("Enter your password")]
        public string password { get; set; }
    }
}