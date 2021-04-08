using System.Collections.Generic;
using CoreProject.Core.Interfaces.Validations;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserInterfaces.Repositories;
using FLentProject.Domain.Users.UserInterfaces.Services;
using FLentProject.Domain.Users.UserInterfaces.Validations;
using FLentProject.Infra.CrossCutting.Auth;

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

        public User Authenticate(Email login, string password)
        {
            var user = _userRepository.GetByLogin(login);
            
            if (user == null)
            {
                _validationNotification.Notifications = _userValidation.AddNotification("Usuário não foi encontrado com login informado.");
                return new User("", null,"");
            }

            if (user.Password != password)
            {
                _validationNotification.Notifications = _userValidation.AddNotification("Senha de usuário não confere com a senha informada.");
                return new User("", null, "");
            }

            user.EditToken(AuthenticationResolver.AuthenticateResolverToken(user));

            _userRepository.Edit(user);

            return user;
        }
    }
}
