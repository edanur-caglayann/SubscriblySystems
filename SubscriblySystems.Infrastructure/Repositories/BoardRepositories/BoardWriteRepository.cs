using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BoardRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BoardRepositories;

public class BoardWriteRepository : WriteRepository<Board>, IBoardWriteRepository
{
    public BoardWriteRepository(AppDbContext context) : base(context)
    {
    }
}