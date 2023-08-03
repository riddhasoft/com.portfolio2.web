using com.portfolio2.web.Models;
using System.ComponentModel.DataAnnotations;

namespace com.portfolio2.web.Controllers.ViewModel
{
    public class SignupViewModel:User
    {
        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
