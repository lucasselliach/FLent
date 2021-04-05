using System.Collections.Generic;
using CoreProject.Core.ValueObjects;
using FlentProject.Domain.Base.People.PersonValidations;
using FlentProject.Domain.Users.UserInterfaces.Validations;
using Flunt.Notifications;
using Flunt.Validations;

namespace FlentProject.Domain.Users.UserValidations
{
    public class UserValidation : PersonValidation, IUserValidation
    {
        private void LoginContract(Email value)
        {
            if (value == null)
            {
                AddNotification("Email", "Email do amigo não pode ser nulo.");
                return;
            }

            AddNotifications(new Contract()
                .AreEquals(value.GetType(), typeof(Email), "Email", "Email do amigo não pode ser diferente do tipo Email.")
                .IsTrue(value.IsValid(), "Email", "Email do amigo não está em um formato valido.")
            );
        }

        private void PasswordContract(string value)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(value, "UserPassword", "Senha do usuário não pode ser nulo ou vazio.")
                .HasMinLen(value, User.MinPasswordLength, "UserPassword", "Senha do usuário não pode ter tamanho menor que " + User.MinPasswordLength + ".")
                .HasMaxLen(value, User.MaxPasswordLength, "UserPassword", "Senha do usuário não pode ter tamanho maior que " + User.MaxPasswordLength + ".")
            );
        }

        private void RolerContract(string value)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(value, "UserRole", "Função do usuário não pode ser nulo ou vazio.")
                .Matchs(value, "^.*(" + User.UserRoleAdmin + "|" + User.UserRoleGeneral + ")$", "UserRole", "Função do usuário não pode ser diferente de " + User.UserRoleAdmin + " e " + User.UserRoleGeneral+ ".")
            );
        }

        public bool Check(User user)
        {
            IdContract(user.Id);
            NameContract(user.Name);
            RegisterDateContract(user.RegisterDate);
            LoginContract(user.Login);
            PasswordContract(user.Password);
            RolerContract(user.Role);

            return Valid;
        }

        public IReadOnlyCollection<Notification> CheckedNotifications()
        {
            return Notifications;
        }

        public IReadOnlyCollection<Notification> AddNotification(string message)
        {
            AddNotification("UserValidationGeneral", message);

            return Notifications;
        }
    }
}
