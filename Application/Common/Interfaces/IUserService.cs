using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(string userId);
        Task<string> GetUserNameAsync(string userId);
        Task<OutputResult<UserDto>> CreateUserAsync(UserDto user);
        Task<Result> DeleteUserAsync(string userId);
        Task<OutputResult<AuthenticationDto>> AuthenticateAsync(string userName, string password);
    }
}
