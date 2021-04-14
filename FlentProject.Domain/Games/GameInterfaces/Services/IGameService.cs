using System.Collections.Generic;
using CoreProject.Core.Interfaces.Services;

namespace FLentProject.Domain.Games.GameInterfaces.Services
{
    public interface IGameService : IServiceBase<Game>
    {
        IEnumerable<Game> GetAllAvailable(string userId);
    }
}
