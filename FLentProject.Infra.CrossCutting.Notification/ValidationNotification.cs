using System.Collections.Generic;
using CoreProject.Core.Interfaces.Validations;

namespace FLentProject.Infra.CrossCutting.Notification
{
    public class ValidationNotification : IValidationNotification
    {
        public IReadOnlyCollection<Flunt.Notifications.Notification> Notifications { get; set; }
    }
}
