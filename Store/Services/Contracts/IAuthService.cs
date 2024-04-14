using Entities.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get;}
        IEnumerable<IdentityUser> Users { get; }
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task<IdentityUser> GetOneUser(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task Update(UserDtoForUpdate userDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto dto);
    }
}
