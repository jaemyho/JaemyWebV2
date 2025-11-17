using System.ComponentModel.DataAnnotations;

namespace JaemyPortfolio.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string? Description { get; set; }

        [StringLength(100, ErrorMessage = "Author cannot be longer than 100 characters")]
        public string? Author { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = false;

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [StringLength(500)]
        public string? Tags { get; set; }
    }
}
