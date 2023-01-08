using Fidar.Infrastructure.Common;
using Fidar.Infrastructure.Persistens;
using Fidar.Infrastructure.Users;
using Fidar.Infrastructure.Users.Contracts;
using Microsoft.Extensions.DependencyInjection;
namespace Fidar.Application;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<UserRepository, DapperUserRepository>();
        services.AddTransient<BaseUnitOfWork, UnitOfWork>();
    }
}
