using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.UserRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.UserRepositories;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(AppDbContext context) : base(context)
    {
    }
}