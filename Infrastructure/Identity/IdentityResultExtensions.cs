using Microsoft.AspNetCore.Identity;
using System.Linq;
using VideoVault.Application.Common.Models;

namespace Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static OutputResult<UserDto> ToApplicationResult(this IdentityResult result, UserDto user)
        {
            return result.Succeeded
                ? OutputResult<UserDto>.Success(user)
                : OutputResult<UserDto>.Failure(result.Errors.Select(e => e.Description));
        }

        public static OutputResult<string> ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? OutputResult<string>.Success("")
                : OutputResult<string>.Failure(result.Errors.Select(e => e.Description));
        }
    }
}