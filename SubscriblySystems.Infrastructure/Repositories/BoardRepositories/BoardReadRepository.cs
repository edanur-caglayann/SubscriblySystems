using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BoardRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BoardRepositories;

public class BoardReadRepository : ReadRepository<Board>, IBoardReadRepository
{
    public BoardReadRepository(AppDbContext context) : base(context)
    {
    }
}