using EventsPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventsPortal.BLL.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(
            int? page = null, int? pageSize = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            );
        TEntity GetByID(object id);
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        void Insert(TEntity entityToInsert);
        void Update(object id, TEntity entityToUpdate);
        bool ExistsID(object id);
    }

    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; }
        IRepository<EventType> EventTypes { get; }
        void Commit();
    }
}
