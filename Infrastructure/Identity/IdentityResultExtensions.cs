using Microsoft.AspNetCore.Identity;
using System.Linq;
using VideoVault.Application.Common.Models;

namespace Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static OutputResult<string> ToApplicationResult(this IdentityResult result, string userId= null)
        {
            return result.Succeeded
                ? OutputResult<string>.Success(userId)
                : OutputResult<string>.Failure(result.Errors.Select(e => e.Description));
        }
    }
}