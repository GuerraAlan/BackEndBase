using BackEndBase.Domain.Commands.Base;
using BackEndBase.Domain.Events;

namespace BackEndBase.Domain.Bus;

public interface IBus
{
    void SendCommand<T>(T command) where T : Command;

    TR SendCommand<T, TR>(T command) where T : Command
        where TR : Event;

    void RaiseEvent<T>(T theEvent) where T : Event;
}