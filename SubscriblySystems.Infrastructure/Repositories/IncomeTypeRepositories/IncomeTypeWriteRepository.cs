using Microsoft.EntityFrameworkCore;
using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories;
using SubscriblySystems.Aplication.Repositories.IncomeRepositories;
using SubscriblySystems.Aplication.Repositories.IncomeTypeRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.IncomeTypeRepositories;

public class IncomeTypeWriteRepository : WriteRepository<IncomeType>, IIncomeTypeWriteRepository
{
    public IncomeTypeWriteRepository(AppDbContext context) : base(context)
    {
    }
}