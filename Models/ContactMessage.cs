using System.ComponentModel.DataAnnotations;

namespace JaemyPortfolio.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Subject cannot be longer than 200 characters")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }
}
