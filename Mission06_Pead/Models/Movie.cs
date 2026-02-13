using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Pead.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Category is required")]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = "G";

        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
