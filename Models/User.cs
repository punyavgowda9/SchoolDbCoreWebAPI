using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolDbCoreWebAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, StringLength(50)]
        public string Role { get; set; }
    }
}