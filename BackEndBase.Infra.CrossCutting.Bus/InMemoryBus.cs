using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Commands.Base;
using BackEndBase.Domain.Events;
using BackEndBase.Domain.Interfaces.Notifications;
using System;

namespace BackEndBase.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        public TR SendCommand<T, TR>(T command)
            where T : Command
            where TR : Event
        {
            var result = Publish<T, TR>(command);
            return result;
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var type = message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>);

            var obj = Container.GetService(type);

            ((IHandler<T>)obj)?.Handle(message);
        }

        private static TR Publish<T, TR>(T message)
            where T : Message
            where TR : Event
        {
            if (Container == null) return null;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T, TR>));

            var result = ((IHandler<T, TR>)obj)?.Handle(message);
            return result;
        }
    }
}