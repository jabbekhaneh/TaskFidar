using Fidar.Infrastructure.Users.Contracts;
namespace Fidar.Infrastructure.Common;

public interface BaseUnitOfWork
{
    UserRepository Users { get; }
}
