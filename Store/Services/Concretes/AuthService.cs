using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace Services.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles
            => _roleManager.Roles;
        public IEnumerable<IdentityUser> Users
            => _userManager.Users;
        public async Task<IdentityUser> GetOneUser(string userName) => await _userManager.FindByNameAsync(userName);
        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
        {
            var user = await GetOneUser(userName);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDtoForUpdate>(user);
                userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
                userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
                return userDto;
            }
            throw new Exception("Getting one user for update operation failed!");
        }
        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
                throw new Exception("Error occured during creating user!");

            if (userDto.Roles.Any())
            {
                var roles = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roles.Succeeded)
                    throw new Exception("Error occured during adding roles to user!");
            }
            return result;
        }
        public async Task Update(UserDtoForUpdate userDto)
        {
            IdentityUser userToUpdate = await GetOneUser(userDto.UserName);
            if (userToUpdate == null)
                throw new Exception("User not found!");
            await _userManager.UpdateAsync(_mapper.Map(userDto, userToUpdate));      
            
            if(userDto.Roles.Any())
            {
                var userRoles = await _userManager.GetRolesAsync(userToUpdate);
                await _userManager.RemoveFromRolesAsync(userToUpdate, userRoles); // Remove all roles
                await _userManager.AddToRolesAsync(userToUpdate, userDto.Roles); // Add new roles according to userDto
                return;
            }
            throw new Exception("Update user operation failed!");
        }
        public async Task<IdentityResult> ResetPassword(ResetPasswordDto dto)
        {
            IdentityUser user = await GetOneUser(dto.UserName);
            
            if(user!=null)
            {
                await _userManager.RemovePasswordAsync(user);
                return await _userManager.AddPasswordAsync(user, dto.Password);
            }       
            else
                return IdentityResult.Failed(new IdentityError { Description = "User not found!" });
        }
    }
}
