using Queue.Flow.Domain.Common;
using Queue.Flow.Domain.Entities;
using Queue.Flow.Domain.ValueObjects;

namespace Queue.Flow.Domain.Specifications;

public class UserByEmailSpecification : BaseSpecification<User>
{
    public UserByEmailSpecification(Email email) : base(u => u.Email == email)
    {
    }
}

public class ActiveUsersSpecification : BaseSpecification<User>
{
    public ActiveUsersSpecification() : base(u => u.IsActive && !u.IsDeleted)
    {
        ApplyOrderBy(u => u.FirstName);
    }
}

public class UsersByRoleSpecification : BaseSpecification<User>
{
    public UsersByRoleSpecification(string role) : base(u => u.Roles.Contains(role) && !u.IsDeleted)
    {
        ApplyOrderBy(u => u.CreatedAt);
    }
}

public class UsersWithConfirmedEmailSpecification : BaseSpecification<User>
{
    public UsersWithConfirmedEmailSpecification() : base(u => u.IsEmailConfirmed && !u.IsDeleted)
    {
        ApplyOrderByDescending(u => u.CreatedAt);
    }
}

public class UsersByNameSpecification : BaseSpecification<User>
{
    public UsersByNameSpecification(string searchTerm) : base(u =>
        (u.FirstName.Contains(searchTerm) || u.LastName.Contains(searchTerm)) && !u.IsDeleted)
    {
        ApplyOrderBy(u => u.FirstName);
    }
}

public class UsersWithProductsSpecification : BaseSpecification<User>
{
    public UsersWithProductsSpecification() : base(u => !u.IsDeleted)
    {
        AddInclude(u => u.Products);
        ApplyOrderBy(u => u.FirstName);
    }
}

public class RecentlyCreatedUsersSpecification : BaseSpecification<User>
{
    public RecentlyCreatedUsersSpecification(int days) : base(u =>
        u.CreatedAt >= DateTime.UtcNow.AddDays(-days) && !u.IsDeleted)
    {
        ApplyOrderByDescending(u => u.CreatedAt);
    }
}

