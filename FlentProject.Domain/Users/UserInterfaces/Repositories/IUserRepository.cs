using CoreProject.Core.Interfaces.Repositories;
using CoreProject.Core.ValueObjects;

namespace FLentProject.Domain.Users.UserInterfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByLogin(Email login);
    }
}
