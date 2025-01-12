using Authentication.Application.Repositories;
using Authentication.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Authentication.Application.AthenticationUser.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(IUserRepository repository,
        IMapper mapper) : IRequestHandler<RegisterUserCommand, RegisterUserCommandResult>
    {
        public async Task<RegisterUserCommandResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request.user);

            await repository.RegisterUser(user, request.Role);

            return new RegisterUserCommandResult(true);
        }
    }
}
