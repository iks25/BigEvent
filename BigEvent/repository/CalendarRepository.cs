using System.Collections.Generic;
using System.Linq;
using BigEvent.Data;
using BigEvent.Models;
using Microsoft.EntityFrameworkCore;

namespace BigEvent.repository
{
    public class CalendarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CalendarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Event> GetUserEvent(int userId)
        {
            var events =
                _dbContext.EventsInCalendar
                    .Include(e => e.Event)
                    .Where(e => e.UserId == userId)
                    .Select(e => e.Event);
                
            return events;
        }
        public IQueryable<Event> GetUserFullEvent(int userId)
        {
            var events =
                _dbContext.EventsInCalendar
                    .Include(e => e.Event)
                    .Include(e =>e.Event.Image)
                    .Include(e=>e.Event.Type)
                    .Include(e=>e.Event.Organizer)
                    .Where(e => e.UserId == userId)
                    .Select(e => e.Event);
                
            return events;
        }
    }
}