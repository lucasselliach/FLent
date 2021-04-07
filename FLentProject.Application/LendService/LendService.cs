using System.Collections.Generic;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Domain.Lends;
using FLentProject.Domain.Lends.LendInterfaces.Repositories;
using FLentProject.Domain.Lends.LendInterfaces.Services;
using FLentProject.Domain.Lends.LendInterfaces.Validations;

namespace FLentProject.Application.LendService
{
    public class LendService : ILendService
    {
        private readonly ILendRepository _lendRepository;
        private readonly ILendValidation _lendValidation;
        private readonly IValidationNotification _validationNotification;

        public LendService(ILendRepository lendRepository, ILendValidation lendValidation, IValidationNotification validationNotification)
        {
            _lendRepository = lendRepository;
            _lendValidation = lendValidation;
            _validationNotification = validationNotification;
        }

        public IEnumerable<Lend> GetAll()
        {
            return _lendRepository.GetAll();
        }

        public Lend GetById(string id)
        {
            return _lendRepository.GetById(id);
        }

        public void Create(Lend entity)
        {
            if (_lendValidation.Check(entity))
            {
                var success = _lendRepository.Create(entity);

                if (success == false) _validationNotification.Notifications = _lendValidation.AddNotification("Lend não foi criado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _lendValidation.CheckedNotifications();
            }
        }

        public void Edit(Lend entity)
        {
            if (_lendValidation.Check(entity))
            {
                var success = _lendRepository.Edit(entity);

                if (success == false) _validationNotification.Notifications = _lendValidation.AddNotification("Lend não foi editado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _lendValidation.CheckedNotifications();
            }
        }

        public void Delete(Lend entity)
        {
            if (_lendValidation.Check(entity))
            {
                var success = _lendRepository.Delete(entity);

                if (success == false) _validationNotification.Notifications = _lendValidation.AddNotification("Lend não foi deletado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _lendValidation.CheckedNotifications();
            }
        }
    }
}
