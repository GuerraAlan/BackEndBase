using BackEndBase.Domain.Events;
using System.Collections.Generic;

namespace BackEndBase.Domain.Interfaces.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();

        List<T> GetNotifications();
    }
}