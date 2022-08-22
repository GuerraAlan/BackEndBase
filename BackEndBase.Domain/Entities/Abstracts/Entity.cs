using System;

namespace BackEndBase.Domain.Entities.Abstracts;

public abstract class Entity<T>
{
    public Guid Id { get; protected set; }

    public override bool Equals(object obj)
    {
        var buff = obj as Entity<T>;

        if (ReferenceEquals(this, buff))
        {
            return true;
        }
        return buff != null && Id.Equals(buff.Id);
    }

    public static bool operator ==(Entity<T> a, Entity<T> b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Entity<T> a, Entity<T> b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id = {Id}]";
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 664) + Id.GetHashCode();
    }
}