using System.Collections.Generic;
using Flunt.Notifications;

namespace CoreProject.Core.Interfaces.Validations
{
    public interface IValidationBase<in TEntity> where TEntity : class
    {
        bool Check(TEntity entity);
        IReadOnlyCollection<Notification> CheckedNotifications();
        IReadOnlyCollection<Notification> AddNotification(string message);
    }
}
