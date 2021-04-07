using CoreProject.Core.Interfaces.Services;
using CoreProject.Core.ValueObjects;

namespace FLentProject.Domain.Users.UserInterfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User Authenticate(Email login, string password);
    }
}
