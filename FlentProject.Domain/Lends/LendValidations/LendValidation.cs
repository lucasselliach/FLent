using System;
using System.Collections.Generic;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Friends.FriendInterfaces.Validations;
using FLentProject.Domain.Games;
using FLentProject.Domain.Games.GameInterfaces.Validations;
using FLentProject.Domain.Lends.LendInterfaces.Validations;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserInterfaces.Validations;
using Flunt.Notifications;
using Flunt.Validations;

namespace FLentProject.Domain.Lends.LendValidations
{
    public class LendValidation : Notifiable, ILendValidation
    {
        private readonly IUserValidation _userValidation;
        private readonly IFriendValidation _friendValidation;
        private readonly IGameValidation _gameValidation;

        public LendValidation(IUserValidation userValidation, IFriendValidation friendValidation, IGameValidation gameValidation)
        {
            _userValidation = userValidation;
            _friendValidation = friendValidation;
            _gameValidation = gameValidation;
        }

        private void IdContract(string value)
        {
            AddNotifications(new Contract()
                .AreNotEquals(value, Guid.Empty, "Id", "Id do objeto não pode ser um GUID vazio.")
            );
        }

        private void UserContract(User value)
        {
            if (value == null)
            {
                AddNotification("User", "Usuário não pode ser nulo.");
                return;
            }

            if (_userValidation.Check(value) == false)
            {
                AddNotifications(_userValidation.CheckedNotifications());
            }
        }

        private void FriendContract(Friend value)
        {
            if (value == null)
            {
                AddNotification("Friend", "Amigo não pode ser nulo.");
                return;
            }

            if (_friendValidation.Check(value) == false)
            {
                AddNotifications(_friendValidation.CheckedNotifications());
            }
        }

        private void GameContract(Game value)
        {
            if (value == null)
            {
                AddNotification("Game", "Jogo não pode ser nulo.");
                return;
            }

            if (_gameValidation.Check(value) == false)
            {
                AddNotifications(_gameValidation.CheckedNotifications());
            }
        }

        private void LendingDateContract(DateTime value)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(value, new DateTime(2021, 01, 01), "LendingDate", "Data do empréstimo não pode ser menor que 01/01/2021.")
            );
        }

        private void DeadlineDateContract(DateTime value)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(value, DateTime.Now, "DeadlineDate", "Data de futura entrega não pode ser menor que a data de agora. " + DateTime.Now.ToString("dd/MM/yyyy HH:MM"))
            );
        }


        public bool Check(Lend lend)
        {
            IdContract(lend.Id);
            UserContract(lend.User);
            FriendContract(lend.Friend);
            GameContract(lend.Game);
            LendingDateContract(lend.LendingDate);
            DeadlineDateContract(lend.DeadlineDate);

            return Valid;
        }

        public IReadOnlyCollection<Notification> CheckedNotifications()
        {
            return Notifications;
        }

        public IReadOnlyCollection<Notification> AddNotification(string message)
        {
            AddNotification("LendValidationGeneral", message);

            return Notifications;
        }
    }
}
