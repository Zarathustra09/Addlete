// User.cs
using System.ComponentModel.DataAnnotations;
namespace Addlete.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username must be between {2} and {1} characters.", MinimumLength = 3)]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be between {2} and {1} characters.", MinimumLength = 6)]
        public string password_hash { get; set; }

        [Required(ErrorMessage = "User role is required.")]
        public int user_role { get; set; }
    }

}
