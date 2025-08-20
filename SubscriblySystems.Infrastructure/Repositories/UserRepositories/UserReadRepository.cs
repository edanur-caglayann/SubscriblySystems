using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.UserRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.UserRepositories;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(AppDbContext context) : base(context)
    {
    }
}