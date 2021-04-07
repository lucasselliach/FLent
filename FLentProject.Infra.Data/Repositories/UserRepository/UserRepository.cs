using System.Collections.Generic;
using System.Linq;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserInterfaces.Repositories;
using FLentProject.Infra.Data.UnitOfWork.Interfaces;

namespace FLentProject.Infra.Data.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<User>().ToHashSet();
        }

        public User GetById(string id)
        {
            var session = _unitOfWork.OpenSession();
            return session.Load<User>(id);
        }

        public bool Create(User entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Store(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id);
        }

        public bool Edit(User entity)
        {
            var session = _unitOfWork.OpenSession();
            var entityChanged = session.Advanced.HasChanged(entity);

            if (entityChanged) session.SaveChanges();

            return entityChanged;
        }

        public bool Delete(User entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Delete(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id) == false;
        }
    }
}
