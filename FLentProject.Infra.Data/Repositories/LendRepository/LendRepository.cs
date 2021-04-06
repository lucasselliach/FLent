using System.Collections.Generic;
using System.Linq;
using FLentProject.Domain.Lends;
using FLentProject.Domain.Lends.LendInterfaces.Repositories;
using FLentProject.Infra.Data.UnitOfWork.Interfaces;

namespace FLentProject.Infra.Data.Repositories.LendRepository
{
    public class LendRepository : ILendRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LendRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Lend> GetAll()
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Lend>().ToHashSet();
        }

        public Lend GetById(string id)
        {
            var session = _unitOfWork.OpenSession();
            return session.Load<Lend>(id);
        }

        public bool Create(Lend entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Store(entity);
            session.SaveChanges();

            return session.Advanced.HasChanged(entity);
        }

        public bool Edit(Lend entity)
        {
            var session = _unitOfWork.OpenSession();
            session.SaveChanges();

            return session.Advanced.HasChanged(entity);
        }

        public bool Delete(Lend entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Delete(entity);
            session.SaveChanges();

            return session.Advanced.Exists(entity.Id) == false;
        }
    }
}
