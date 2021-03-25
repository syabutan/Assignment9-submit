using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MovieInfo
    {
        [Key]
        public int MovieId { get; set;}
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Year filed is required")]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string Lent_to { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
