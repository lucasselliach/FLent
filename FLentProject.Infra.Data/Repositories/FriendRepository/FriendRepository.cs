using System.Collections.Generic;
using System.Linq;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Friends.FriendInterfaces.Repositories;
using FLentProject.Infra.Data.UnitOfWork.Interfaces;

namespace FLentProject.Infra.Data.Repositories.FriendRepository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public FriendRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Friend> GetAll(string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Friend>().Where(x => x.UserId == userId).ToHashSet();
        }

        public Friend GetById(string id, string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Friend>().FirstOrDefault(x => x.UserId == userId);
        }

        public bool Create(Friend entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Store(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id);
        }

        public bool Edit(Friend entity)
        {
            var session = _unitOfWork.OpenSession();
            var entityChanged = session.Advanced.HasChanged(entity);

            if (entityChanged) session.SaveChanges();

            return entityChanged;
        }

        public bool Delete(Friend entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Delete(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id) == false;
        }
    }
}
