using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Account
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Password is required")]
        public string? Email { get; init; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }
        public HashSet<string> Roles { get; set; } = new();
    }
}