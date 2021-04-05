using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace FlentProject.Domain.Base.People.PersonValidations
{
    public abstract class PersonValidation : Notifiable
    {
        protected void IdContract(string value)
        {
            AddNotifications(new Contract()
                .AreNotEquals(value, Guid.Empty, "Id", "Id do objeto não pode ser um GUID vazio.")
            );
        }

        protected void NameContract(string value)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(value, "PersonName", "Nome da pessoa não pode ser nulo ou vazio.")
                .HasMinLen(value, Person.MinNameLength, "PersonName", "Nome da pessoa não pode ter tamanho menor que " + Person.MinNameLength + ".")
                .HasMaxLen(value, Person.MaxNameLength, "PersonName", "Nome da pessoa não pode ter tamanho maior que " + Person.MaxNameLength + ".")
            );
        }

        protected void RegisterDateContract(DateTime value)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(value, new DateTime(2021, 01, 01), "RegisterDate", "Data do registro da pessoa não pode ser menor que 01/01/2021.")
            );
        }
    }
}
