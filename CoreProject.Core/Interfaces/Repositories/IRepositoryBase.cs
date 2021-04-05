using System.Collections.Generic;
using CoreProject.Core.Entities;

namespace CoreProject.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);

        bool Create(TEntity entity);
        bool Edit(TEntity entity);
        bool Delete(TEntity entity);
    }
}
