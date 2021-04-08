using System.Collections.Generic;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Domain.Games;
using FLentProject.Domain.Games.GameInterfaces.Repositories;
using FLentProject.Domain.Games.GameInterfaces.Services;
using FLentProject.Domain.Games.GameInterfaces.Validations;

namespace FLentProject.Application.GameService
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameValidation _gameValidation;
        private readonly IValidationNotification _validationNotification;

        public GameService(IGameRepository gameRepository, IGameValidation gameValidation, IValidationNotification validationNotification)
        {
            _gameRepository = gameRepository;
            _gameValidation = gameValidation;
            _validationNotification = validationNotification;
        }


        public IEnumerable<Game> GetAll(string userId)
        {
            return _gameRepository.GetAll(userId);
        }

        public Game GetById(string id, string userId)
        {
            return _gameRepository.GetById(id, userId);
        }

        public void Create(Game entity)
        {
            if (_gameValidation.Check(entity))
            {
                var success = _gameRepository.Create(entity);

                if (success == false) _validationNotification.Notifications = _gameValidation.AddNotification("Game não foi criado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _gameValidation.CheckedNotifications();
            }
        }

        public void Edit(Game entity)
        {
            if (_gameValidation.Check(entity))
            {
                var success = _gameRepository.Edit(entity);

                if (success == false) _validationNotification.Notifications = _gameValidation.AddNotification("Game não foi editado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _gameValidation.CheckedNotifications();
            }
        }

        public void Delete(Game entity)
        {
            if (_gameValidation.Check(entity))
            {
                var success = _gameRepository.Delete(entity);

                if (success == false) _validationNotification.Notifications = _gameValidation.AddNotification("Game não foi deletado com sucesso.");
            }
            else
            {
                _validationNotification.Notifications = _gameValidation.CheckedNotifications();
            }
        }
    }
}
