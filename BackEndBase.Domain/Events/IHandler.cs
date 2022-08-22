namespace BackEndBase.Domain.Events;

public interface IHandler<in T> where T : Message
{
    void Handle(T message);
}

public interface IHandler<in T, out R>
    where T : Message
    where R : Message
{
    R Handle(T message);
}