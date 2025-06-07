using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.UI.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        public string?  FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        public string? Password { get; set; }

        [Required(ErrorMessage = "User name is required.")]

        public string? UserName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? PhoneNumber { get; set; }

        public ICollection<string>? Role { get; set; }

    }
}
