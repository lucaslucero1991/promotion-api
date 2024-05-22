using CalendarWebApi.DataAccess;
using CalendarWebApi.DTO;
using CalendarWebApi.Models;

namespace CalendarWebApi.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IRepository _repository;
        
        public CalendarService(IRepository repository)
        {
            _repository = repository;
        }
        public Task<Calendar> AddEvent(CreateForm calendarEvent)
        {
            var calendar = new Calendar
            {
                Name = calendarEvent.Name ?? string.Empty,
                Location = calendarEvent.Location ?? string.Empty,
                Time = calendarEvent.Time ?? calendarEvent.Time.Value,
                EventOrganizer = calendarEvent.EventOrganizer ?? string.Empty,
                Members = calendarEvent.Members ?? string.Empty,

            };

            return _repository.AddEvent(calendar);
        }

        public Task<Calendar> DeleteEvent(int id)
        {
            var calendar =  GetCalendar(id);
            if (calendar.Result == null)
            {
                throw new BadHttpRequestException("this event doesn't exists", id);
            }

            return _repository.DeleteEvent(calendar.Result);
        }
        
        public async Task<List<Calendar>> GetCalendar()
        {
            return await _repository.GetCalendar();
        }

        public Task<Calendar> GetCalendar(int id)
        {
            var calendars =  _repository.GetCalendar(id);
            if (calendars.Result == null)
            {
                throw new KeyNotFoundException("this event doesn't exists");
            }

            return calendars;
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
            var calendarExist =  GetCalendar(id);
            if (calendarExist.Result == null)
            {
                throw new KeyNotFoundException("this event doesn't exists");
            }
            
            var calendar = new Calendar
            {
                Name = calendarEvent.Name ?? string.Empty,
                Location = calendarEvent.Location ?? string.Empty,
                Time = calendarEvent.Time ?? calendarEvent.Time.Value,
                EventOrganizer = calendarEvent.EventOrganizer ?? string.Empty,
                Members = calendarEvent.Members ?? string.Empty,

            };

            return _repository.UpdateEvent(calendar);
        }
    }
}
