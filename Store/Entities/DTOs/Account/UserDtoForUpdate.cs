namespace Entities.DTOs.Account
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new();    
    }
}
