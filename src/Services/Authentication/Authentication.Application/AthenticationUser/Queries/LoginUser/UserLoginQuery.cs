using AuthService.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Authentication.Application.AthenticationUser.Queries.LoginUser
{
    public record UserLoginQuery(string Email, string Password) : IRequest<UserLoginQueryResult>;

    public record UserLoginQueryResult(UserDTO user);

    public class UserLoginValidator : AbstractValidator<UserLoginQuery>
    {
        public UserLoginValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
