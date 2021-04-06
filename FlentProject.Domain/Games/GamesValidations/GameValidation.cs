using System;
using System.Collections.Generic;
using FLentProject.Domain.Games.GameInterfaces.Validations;
using Flunt.Notifications;
using Flunt.Validations;

namespace FLentProject.Domain.Games.GamesValidations
{
    public class GameValidation : Notifiable, IGameValidation
    {
        private void IdContract(string value)
        {
            AddNotifications(new Contract()
                .AreNotEquals(value, Guid.Empty, "Id", "Id do objeto não pode ser um GUID vazio.")
            );
        }

        private void NameContract(string value)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(value, "GameName", "Nome do jogo não pode ser nulo ou vazio.")
                .HasMinLen(value, Game.MinNameLength, "GameName", "Nome do jogo não pode ter tamanho menor que " + Game.MinNameLength + ".")
                .HasMaxLen(value, Game.MaxNameLength, "GameName", "Nome do jogo não pode ter tamanho maior que " + Game.MaxNameLength + ".")
            );
        }

        private void RegisterDateContract(DateTime value)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(value, new DateTime(2021, 01, 01), "RegisterDate", "Data do registro do jogo não pode ser menor que 01/01/2021.")
            );
        }

        public bool Check(Game game)
        {
            IdContract(game.Id);
            NameContract(game.Name);
            RegisterDateContract(game.RegisterDate);

            return Valid;
        }

        public IReadOnlyCollection<Notification> CheckedNotifications()
        {
            return Notifications;
        }

        public IReadOnlyCollection<Notification> AddNotification(string message)
        {
            AddNotification("GameValidationGeneral", message);

            return Notifications;
        }
    }
}
