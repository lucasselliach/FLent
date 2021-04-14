﻿using System.Collections.Generic;
using CoreProject.Core.Interfaces.Repositories;

namespace FLentProject.Domain.Games.GameInterfaces.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        IEnumerable<Game> GetAllAvailable(string userId);
    }
}
