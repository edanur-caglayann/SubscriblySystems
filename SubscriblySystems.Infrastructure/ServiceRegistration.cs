using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using subscriblySystem.Infrastructure.Context;

namespace SubscriblySystems.Infrastructure;

public class ServiceRegistration
{
   public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

   }
}