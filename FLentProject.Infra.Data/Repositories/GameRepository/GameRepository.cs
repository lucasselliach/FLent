using System.Collections.Generic;
using System.Linq;
using FLentProject.Domain.Games;
using FLentProject.Domain.Games.GameInterfaces.Repositories;
using FLentProject.Infra.Data.UnitOfWork.Interfaces;

namespace FLentProject.Infra.Data.Repositories.GameRepository
{
    public class GameRepository : IGameRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Game> GetAll(string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Game>().Where(x => x.UserId == userId).ToHashSet();
        }

        public Game GetById(string id, string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Game>().FirstOrDefault(x => x.UserId == userId && x.Id == id);
        }

        public int GetCount(string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Game>().Count(x => x.UserId == userId);
        }

        public bool Create(Game entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Store(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id);
        }

        public bool Edit(Game entity)
        {
            var session = _unitOfWork.OpenSession();
            var entityChanged = session.Advanced.HasChanged(entity);
            
            if(entityChanged) session.SaveChanges();

            return entityChanged;
        }

        public bool Delete(Game entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Delete(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id) == false;
        }

        public IEnumerable<Game> GetAllAvailable(string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Game>().Where(x => x.UserId == userId && x.Lent == false).ToHashSet();
        }
    }
}
