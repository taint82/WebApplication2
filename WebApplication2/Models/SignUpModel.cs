using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class SignUpModel
    {
        [Required]
        public string NameFirst { get; set; } = null!;
        [Required]
        public string NameLast { get; set; } = null!;
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
