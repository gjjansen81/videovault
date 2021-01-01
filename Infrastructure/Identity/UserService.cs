using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return _mapper.Map<List<UserDto>>(await _userManager.Users.ToListAsync());
        }

        public async Task<UserDto> GetUserAsync(string userId)
        {
            return _mapper.Map<UserDto>(await _userManager.Users.FirstAsync(u => u.Id == userId));
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<OutputResult<UserDto>> UpsertUserAsync(UserDto user)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(user);

            IdentityResult result = null;
            if (user.Id == Guid.Empty)
            {
                applicationUser.Id = Guid.NewGuid().ToString();
                result = await _userManager.CreateAsync(applicationUser, user.Password);
            }
            else
                result = await _userManager.UpdateAsync(applicationUser);
            
            return result.ToApplicationResult(user);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<OutputResult<AuthenticationDto>> AuthenticateAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var loginResult = await _userManager.CheckPasswordAsync(user, password );
            if (!loginResult)
            {
                return new OutputResult<AuthenticationDto>() { Output = null };
            }

            user.UserRoles = (await _userManager.GetRolesAsync(user)).Select(x => new IdentityRole(x.ToLower()));

            var signingKey = Convert.FromBase64String(_configuration["Jwt:Key"]);
            var expiryDuration = int.Parse(_configuration["Jwt:ExpiryDuration"]);
            DateTime expirationDate = DateTime.UtcNow.AddMinutes(expiryDuration);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = expirationDate,
                Subject = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("userid", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, $"[\"{string.Join("\",\"",user.UserRoles.Select(x => x.Name))}\"]")
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return new OutputResult<AuthenticationDto>() { Output = new AuthenticationDto(){ Token = token , ExpirationDate = expirationDate}, Succeeded = true};
        }

        public async Task<Result> SetPasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, newPassword);
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded)
            {
                // change password has been succeeded
            }

            return new Result() { Succeeded = res.Succeeded };
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
    }
}
