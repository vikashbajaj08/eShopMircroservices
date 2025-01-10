using AuthService.Application.DTOs;
using MediatR;

namespace Authentication.Application.AthenticationUser.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<GetUsersQueryResult>;

    public record GetUsersQueryResult(IEnumerable<UserDTO> users);
}
