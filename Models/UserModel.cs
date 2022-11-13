using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class UserModel
    {
        //Ignore this page (Work in Progress)

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}