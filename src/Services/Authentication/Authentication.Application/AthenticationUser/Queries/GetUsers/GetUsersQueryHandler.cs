using Authentication.Application.Repositories;
using AuthService.Application.DTOs;
using AutoMapper;
using MediatR;

namespace Authentication.Application.AthenticationUser.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<GetUsersQuery, GetUsersQueryResult>
    {
        public async Task<GetUsersQueryResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetAll();

            var users = mapper.Map<IEnumerable<UserDTO>>(response);

            return new GetUsersQueryResult(users);
        }
    }
}
