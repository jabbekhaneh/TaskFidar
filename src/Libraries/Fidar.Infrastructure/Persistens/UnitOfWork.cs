using Fidar.Infrastructure.Common;
using Fidar.Infrastructure.Users.Contracts;

namespace Fidar.Infrastructure.Persistens;

public class UnitOfWork : BaseUnitOfWork
{
    public UnitOfWork(UserRepository userRepository)
    {
        Users = userRepository;
    }
    public UserRepository Users { get; }
}
