using System.Collections.Generic;
using CoreProject.Core.Entities;

namespace CoreProject.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll(string userId);
        TEntity GetById(string id, string userId);
        int GetCount(string userId);

        bool Create(TEntity entity);
        bool Edit(TEntity entity);
        bool Delete(TEntity entity);
    }
}
