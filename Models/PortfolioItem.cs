using System.ComponentModel.DataAnnotations;

namespace JaemyPortfolio.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Project URL cannot be longer than 500 characters")]
        public string? ProjectUrl { get; set; }

        [StringLength(500, ErrorMessage = "GitHub URL cannot be longer than 500 characters")]
        public string? GitHubUrl { get; set; }

        [StringLength(500, ErrorMessage = "Image URL cannot be longer than 500 characters")]
        public string? ImageUrl { get; set; }

        [StringLength(500, ErrorMessage = "Technologies cannot be longer than 500 characters")]
        public string? Technologies { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
