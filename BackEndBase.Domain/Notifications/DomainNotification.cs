using BackEndBase.Domain.Events;
using System;

namespace BackEndBase.Domain.Notifications;

public class DomainNotification : Event
{
    public Guid DomainNotificationId { get; private set; }
    public string Key { get; private set; }
    public string Value { get; private set; }
    public string Version { get; private set; }

    public DomainNotification(string key, string value)
    {
        DomainNotificationId = Guid.NewGuid();
        Key = key;
        Value = value;
        Version = "1.0";
    }
}