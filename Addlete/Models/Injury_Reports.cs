using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Addlete.Models
{
    public class Injury_Reports
    {
        [Key]
        public int report_id { get; set; }

        [Required(ErrorMessage = "Athlete ID is required.")]
        [ForeignKey("Athlete")]
        public int athlete_id { get; set; }

        [Required(ErrorMessage = "Injury description is required.")]
        public string injury_description { get; set; }

        [Required(ErrorMessage = "Date reported is required.")]
        [DataType(DataType.Date)]
        public DateTime date_reported { get; set; }

        // Navigation property
        public Athlete? Athlete { get; set; }
    }
}
