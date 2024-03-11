using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Addlete.Models
{
    public class Athlete
    {
        [Key]
        public int athlete_id { get; set; }

        [Required(ErrorMessage = "Athlete name is required.")]
        [StringLength(100, ErrorMessage = "Athlete name must be at most 100 characters.")]
        public string athlete_name { get; set; }

        [Required(ErrorMessage = "Sport is required.")]
        [StringLength(50, ErrorMessage = "Sport must be at most 50 characters.")]
        public string sport { get; set; }

        [Display(Name = "Coach")]
        [ForeignKey("Coach")]
        public int? coach_id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; }

        // Navigation property
        public Coach? Coach { get; set; }
    }
}
