﻿using System.Collections.Generic;
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

        public IEnumerable<Lend> GetAll(string userId)
        {
            var session = _unitOfWork.OpenSession();            
            return session.Query<Lend>().Where(x=>x.UserId == userId).ToHashSet();
        }

        public Lend GetById(string id, string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Lend>().FirstOrDefault(x => x.UserId == userId && x.Id == id);
        }

        public int GetCount(string userId)
        {
            var session = _unitOfWork.OpenSession();
            return session.Query<Lend>().Count(x => x.UserId == userId);
        }

        public bool Create(Lend entity)
        {
            var session = _unitOfWork.OpenSession();
            session.Store(entity);
            session.SaveChanges();
            
            return session.Advanced.Exists(entity.Id);
        }

        public bool Edit(Lend entity)
        {
            var session = _unitOfWork.OpenSession();
            var entityChanged = session.Advanced.HasChanged(entity);

            if (entityChanged) session.SaveChanges();

            return entityChanged;
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
