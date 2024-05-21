using CalendarWebApi.DTO;
using CalendarWebApi.Models;

namespace CalendarWebApi.Services
{
    public class CalendarService : ICalendarService
    {
        public Task<Calendar> AddEvent(CreateForm calendarEvent)
        {
            throw new NotImplementedException();
        }

        public Task<Calendar> DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Calendar>> GetCalendar()
        {
            throw new NotImplementedException();
        }

        public Task<Calendar> GetCalendar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Calendar>> GetCalendar(Query query)
        {
            throw new NotImplementedException();
        }

        public Task<List<Calendar>> GetEventsSorted()
        {
            throw new NotImplementedException();
        }

        public Task<Calendar> UpdateEvent(int id, UpdateForm calendarEvent)
        {
            throw new NotImplementedException();
        }
    }
}
