using FluentValidation;

namespace VideoVault.Application.Common.Users.Commands
{
    public class GetUsersCommandValidator : AbstractValidator<GetUsersCommand>
    {
        public GetUsersCommandValidator()
        {
        }
    }
}
