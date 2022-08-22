using BackEndBase.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BackEndBase.Domain.Interfaces.Data;

public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity<TEntity>
{
    void Add(TEntity obj);

    TEntity GetById(Guid id, params Expression<Func<TEntity, object>>[] include);

    ICollection<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include);

    ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);

    TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);

    void Update(TEntity obj);

    void Remove(Guid id);

    void Remove(TEntity entity);

    void Save();
}