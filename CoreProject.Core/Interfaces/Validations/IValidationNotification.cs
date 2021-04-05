using System.Collections.Generic;
using Flunt.Notifications;

namespace CoreProject.Core.Interfaces.Validations
{
    public interface IValidationNotification
    {
        IReadOnlyCollection<Notification> Notifications { get; set; }
    }
}
