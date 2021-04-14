using System.Collections.Generic;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Friends.FriendInterfaces.Repositories;
using FLentProject.Domain.Friends.FriendInterfaces.Services;
using FLentProject.Domain.Friends.FriendInterfaces.Validations;

namespace FLentProject.Application.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IFriendValidation _friendValidation;
        private readonly IValidationNotification _validationNotification;

        public FriendService(IFriendRepository friendRepository, IFriendValidation friendValidation, IValidationNotification validationNotification)
        {
            _friendRepository = friendRepository;
            _friendValidation = friendValidation;
            _validationNotification = validationNotification;
        }


        public IEnumerable<Friend> GetAll(string userId)
        {
            return _friendRepository.GetAll(userId);
        }

        public Friend GetById(string id, string userId)
        {
            return _friendRepository.GetById(id, userId);
        }

        public int GetCount(string userId)
        {
            return _friendRepository.GetCount(userId);
        }

        public void Create(Friend entity)
        {
            if (_friendValidation.Check(entity))
            {
                var success = _friendRepository.Create(entity);

                if (success == false) _validationNotification.Notifications = _friendValidation.AddNotification("Friend não foi criado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _friendValidation.CheckedNotifications();
            }
        }

        public void Edit(Friend entity)
        {
            if (_friendValidation.Check(entity))
            {
                var success = _friendRepository.Edit(entity);

                if (success == false) _validationNotification.Notifications = _friendValidation.AddNotification("Friend não foi editado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _friendValidation.CheckedNotifications();
            }
        }

        public void Delete(Friend entity)
        {
            if (_friendValidation.Check(entity))
            {
                var success = _friendRepository.Delete(entity);

                if (success == false) _validationNotification.Notifications = _friendValidation.AddNotification("Friend não foi deletado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _friendValidation.CheckedNotifications();
            }
        }
    }
}
