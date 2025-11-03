using Queue.Flow.Application.Interfaces;
using Queue.Flow.Domain.Entities;
using Queue.Flow.Domain.Specifications;
using Queue.Flow.Domain.ValueObjects;
using Queue.Flow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Queue.Flow.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(QueueDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        var spec = new UserByEmailSpecification(email);
        return await GetBySpecAsync(spec, cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        var spec = new UserByEmailSpecification(email);
        return await ExistsAsync(spec, cancellationToken);
    }

    public async Task<List<User>> GetActiveUsersAsync(CancellationToken cancellationToken = default)
    {
        var spec = new ActiveUsersSpecification();
        return await GetListAsync(spec, cancellationToken);
    }

    public async Task<List<User>> GetUsersByRoleAsync(string role, CancellationToken cancellationToken = default)
    {
        var spec = new UsersByRoleSpecification(role);
        return await GetListAsync(spec, cancellationToken);
    }
}

