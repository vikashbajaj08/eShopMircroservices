using AuthService.Application.DTOs;
using FluentValidation;
using MediatR;
using System.Windows.Input;

namespace Authentication.Application.AthenticationUser.Commands.RegisterUser
{
    public record RegisterUserCommand(UserRegisterDTO user, string Role) : IRequest<RegisterUserCommandResult>;

    public record RegisterUserCommandResult(bool success);

    public class RegisterUserCommandvalidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandvalidator()
        {
            RuleFor(u=>u.user.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(u => u.user.PhoneNumber).NotEmpty().WithMessage("Phone Number is required");
            RuleFor(u => u.user.Password).NotEmpty().WithMessage("Password is required");
        }
    }
        
}
