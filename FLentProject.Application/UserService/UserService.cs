using System.Collections.Generic;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserInterfaces.Repositories;
using FLentProject.Domain.Users.UserInterfaces.Services;
using FLentProject.Domain.Users.UserInterfaces.Validations;

namespace FLentProject.Application.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidation _userValidation;
        private readonly IValidationNotification _validationNotification;

        public UserService(IUserRepository userRepository, IUserValidation userValidation, IValidationNotification validationNotification)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
            _validationNotification = validationNotification;
        }


        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public void Create(User entity)
        {
            if (_userValidation.Check(entity))
            {
                var success = _userRepository.Create(entity);

                if (success == false) _validationNotification.Notifications = _userValidation.AddNotification("User não foi criado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _userValidation.CheckedNotifications();
            }
        }

        public void Edit(User entity)
        {
            if (_userValidation.Check(entity))
            {
                var success = _userRepository.Edit(entity);

                if (success == false) _validationNotification.Notifications = _userValidation.AddNotification("User não foi editado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _userValidation.CheckedNotifications();
            }
        }

        public void Delete(User entity)
        {
            if (_userValidation.Check(entity))
            {
                var success = _userRepository.Delete(entity);

                if (success == false) _validationNotification.Notifications = _userValidation.AddNotification("User não foi deletado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _userValidation.CheckedNotifications();
            }
        }
    }
}
