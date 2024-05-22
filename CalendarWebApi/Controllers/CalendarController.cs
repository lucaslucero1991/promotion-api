using CalendarWebApi.DTO;
using CalendarWebApi.Models;
using CalendarWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalendarWebApi.Controllers
{
    [ApiController]
    [Route("api/calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly ICalendarService _calendarService;

        public CalendarController(ILogger<CalendarController> logger,
            ICalendarService calendarService)
        {
            _logger = logger;
            _calendarService = calendarService;
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Calendar? calendar)
        {
            if (calendar == null)
            {
                return BadRequest("calendar body is null");
            }

            var formDTO = new CreateForm
            {
                Name = calendar.Name,
                Location = calendar.Location,
                EventOrganizer = calendar.EventOrganizer,
                Members = calendar.Members,
                Time = calendar.Time
            };

            var response = _calendarService.AddEvent(formDTO);
            
            return CreatedAtAction(nameof(CreateEvent),
                new { id = response.Id }, response);
        }
    }
}
