using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using subscriblySystem.Infrastructure.Context;

namespace SubscriblySystems.Infrastructure;

public static class ServiceRegistration 
{
   public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

   }
}
// extantion 
// this dedigime yetenek kazndirmis oluyorum