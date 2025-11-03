using Queue.Flow.Domain.Entities;
using Queue.Flow.Domain.ValueObjects;

namespace Queue.Flow.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<bool> ExistsByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<List<User>> GetActiveUsersAsync(CancellationToken cancellationToken = default);
    Task<List<User>> GetUsersByRoleAsync(string role, CancellationToken cancellationToken = default);
}

