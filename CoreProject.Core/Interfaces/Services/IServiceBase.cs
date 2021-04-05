using System.Collections.Generic;
using CoreProject.Core.Entities;

namespace CoreProject.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);

        void Create(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}
