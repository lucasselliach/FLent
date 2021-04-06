using System.Collections.Generic;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Base.People.PersonValidations;
using FLentProject.Domain.Friends.FriendInterfaces.Validations;
using Flunt.Notifications;
using Flunt.Validations;

namespace FLentProject.Domain.Friends.FriendValidations
{
    public class FriendValidation : PersonValidation, IFriendValidation
    {
        private void NickNameContract(string value)
        {
            AddNotifications(new Contract()
                .IsNotNull(value, "FriendNickName", "Apelido da pessoa não pode ser nulo.")
                .HasMaxLen(value, Friend.MaxNickNameLength, "FriendNickName", "Apelido da pessoa não pode ter tamanho maior que " + Friend.MaxNickNameLength + ".")
            );
        }

        private void EmailContract(Email value)
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

        private void PhoneNumber01Contract(Phone value)
        {
            if (value == null)
            {
                AddNotification("PhoneNumber01", "Telefone 01 do amigo não pode ser nulo.");
                return;
            }

            AddNotifications(new Contract()
                .AreEquals(value.GetType(), typeof(Phone), "PhoneNumber01", "Telefone do amigo não pode ser diferente do tipo Phone.")
                .IsTrue(value.IsValid(), "PhoneNumber01", "Telefone do amigo não está em um formato valido.")
            );
        }

        public bool Check(Friend friend)
        {
            IdContract(friend.Id);
            NameContract(friend.Name);
            RegisterDateContract(friend.RegisterDate);
            NickNameContract(friend.NickName);
            EmailContract(friend.Email);
            PhoneNumber01Contract(friend.PhoneNumber01);

            return Valid;
        }

        public IReadOnlyCollection<Notification> CheckedNotifications()
        {
            return Notifications;
        }

        public IReadOnlyCollection<Notification> AddNotification(string message)
        {
            AddNotification("FriendValidationGeneral", message);

            return Notifications;
        }
    }
}
