using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAsync();
        Task<UserDto> GetSingleAsync(string userId);
        Task<string> GetUserNameAsync(string userId);
        Task<OutputResult<UserDto>> UpsertAsync(UserDto user);
        Task<Result> DeleteAsync(string userId);
        Task<OutputResult<AuthenticationDto>> AuthenticateAsync(string userName, string password);
        Task<Result> SetPasswordAsync(string userId, string newPassword);
        Task<List<UserDto>> GetUsersOfCustomerAsync(int customerId);
    }
}
