using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Account
{
    public record ResetPasswordDto
    {
        public string UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password confirmation is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
