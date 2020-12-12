using BackendBase.DataAccess.Context;
using BackEndBase.Domain.Entities.Abstracts;
using BackEndBase.Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BackendBase.DataAccess.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly BaseContext _context;

        protected RepositoryBase(BaseContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> DbSet()
        {
            return _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet().Add(entity);
        }

        public virtual TEntity GetById(Guid id, params Expression<Func<TEntity, object>>[] include)
        {
            Expression<Func<TEntity, bool>> predicate = x => x.Id == id;
            return Find(predicate, include).FirstOrDefault();
        }

        public virtual ICollection<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include)
        {
            return Find(e => true, include);
        }

        public virtual ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include)
        {
            if (predicate == null) return null;

            IQueryable<TEntity> query = DbSet();

            if (include != null)
            {
                query = include.Aggregate(query, (current, item) => current.Include(item));
            }

            return query.Where(predicate).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include)
        {
            if (predicate == null) return null;

            IQueryable<TEntity> query = DbSet();

            if (include != null)
            {
                query = include.Aggregate(query, (current, item) => current.Include(item));
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet().Update(entity);
        }

        public virtual void Remove(Guid id)
        {
            Remove(GetById(id));
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet().Remove(entity);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}