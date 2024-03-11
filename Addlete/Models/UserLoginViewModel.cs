using System.ComponentModel.DataAnnotations;

namespace Addlete.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
