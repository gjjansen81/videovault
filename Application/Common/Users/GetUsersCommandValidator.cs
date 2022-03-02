using FluentValidation;

namespace VideoVault.Application.Common.Users
{
    public class GetUsersCommandValidator : AbstractValidator<GetUsersCommand>
    {
        public GetUsersCommandValidator()
        {
        }
    }
}
