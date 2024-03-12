using System;
using System.ComponentModel.DataAnnotations;

namespace Addlete.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public bool AllDay { get; set; }
    }
}
