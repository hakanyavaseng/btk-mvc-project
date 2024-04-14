using AutoMapper;
using Entities.DTOs.Account;
using Microsoft.AspNetCore.Identity;
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
    }
}
