using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<OutputResult<string>> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
