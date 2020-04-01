using EventsPortal.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace EventsPortal.BLL.UnitOfWork
{
    class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        internal EventsPortalDbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        private bool _disposed = false;

        public BaseRepository(EventsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            if (!ExistsID(id))
                throw new ArgumentException("This ID doesn't exists");

            Delete(_dbSet.Find(id));
        }

        public IEnumerable<TEntity> GetAll(
            int? page = null, int? pageSize = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null
            )
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (order != null)
                query = order(query);


            if (page != null && pageSize != null)
                query = query.GetPaged(page ?? 0, pageSize ?? 0).Results.AsQueryable();

            return query.ToList();

        }

        public TEntity GetByID(object id)        {
            
            return _dbSet.Find(id);
        }

        public bool ExistsID(object id)        {
            
            return GetByID(id) != null ? true : false;
        }

        public void Insert(TEntity entityToInsert)
        {
            _dbSet.Add(entityToInsert);
        }

        public void Update(object id, TEntity entityToUpdate)
        {
            if (!ExistsID(id))
                throw new ArgumentException("This ID doesn't exists");

            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
