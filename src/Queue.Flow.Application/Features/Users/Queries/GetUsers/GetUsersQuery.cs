using Queue.Flow.Application.DTOs;
using Queue.Flow.Application.DTOs.Common;
using MediatR;

namespace Queue.Flow.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : PaginationQuery, IRequest<PaginatedResult<UserDto>>
{
    public bool? IsActive { get; set; }
    public bool? IsEmailConfirmed { get; set; }
    public string? Role { get; set; }
}

