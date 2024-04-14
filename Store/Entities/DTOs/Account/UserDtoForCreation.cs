using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Account
{
    public record UserDtoForCreation : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
