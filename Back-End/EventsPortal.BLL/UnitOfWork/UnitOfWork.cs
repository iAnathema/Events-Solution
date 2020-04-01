using EventsPortal.BLL.UnitOfWork;
using EventsPortal.DAL.Models;


public class UnitOfWork : IUnitOfWork
{

    private EventsPortalDbContext _dbContext;
    private BaseRepository<Event> _events;
    private BaseRepository<EventType> _eventTypes;

    public UnitOfWork(EventsPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRepository<Event> Events
    {
        get
        {
            return _events ?? (_events = new BaseRepository<Event>(_dbContext));
        }
    }

    public IRepository<EventType> EventTypes
    {
        get
        {
            return _eventTypes ?? (_eventTypes = new BaseRepository<EventType>(_dbContext));
        }
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}