using Authentication.Application.Repositories;
using AuthService.Application.DTOs;
using AutoMapper;
using MediatR;

namespace Authentication.Application.AthenticationUser.Queries.LoginUser
{
    public class UserLoginQueryHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<UserLoginQuery, UserLoginQueryResult>
    {
        public async Task<UserLoginQueryResult> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {

            var login = await repository.LoginUser(request.Email, request.Password);

            var user = mapper.Map<UserDTO>(login);

            return new UserLoginQueryResult(user);

        }
    }
}
