using System.ComponentModel.DataAnnotations;

namespace Mission06_Pead.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied to Plex is required")]
        public bool? CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
    }
}
