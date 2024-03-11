using System.ComponentModel.DataAnnotations;

namespace Addlete.Models
{
    public class Coach
    {
        [Key]
        public int coach_id { get; set; }

        [Required(ErrorMessage = "Coach name is required.")]
        [StringLength(100, ErrorMessage = "Coach name must be at most 100 characters.")]
        public string coach_name { get; set; }

        [StringLength(100, ErrorMessage = "Specialization must be at most 100 characters.")]
        public string specialization { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; }
    }
}
