using EventsPro.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventsPro.Model;

namespace EventsPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _context;
    
        public EventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                var events = _context.Events.ToList();
                if (events.Count == 0)
                {
                    return NotFound("No events found");

                }
                return Ok(events);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{EventId}")]
        public IActionResult Get(int EventId)
        {
            try
            {
                var events = _context.Events.Find(EventId);
                if (events == null)
                {
                    return NotFound("Events Not Found");
                }
                return Ok(events);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPost]

        public IActionResult Post(Event model)
        {
            try
            {
                _context.Events.Add(model);
                _context.SaveChanges();
                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           

        }
        [HttpPut]
        public IActionResult Put(Event model)
        {
            if (model == null || model.EventID == 0)
            {
                if (model == null)
                {
                    return BadRequest("Invalid data");
                }
                else if (model.EventID == 0)
                {
                    return BadRequest($"Invalid event Id {model.EventID}");
                }
            }
            try
            {
                var Event = _context.Events.Find(model.EventID);
                if (Event == null)
                {
                    return BadRequest("Invalid Id");
                }
                Event.EventName = model.EventName;
                Event.DateOfEvent = model.DateOfEvent;
                Event.Address1 = model.Address1;
                Event.Address2 = model.Address2;
                Event.Number = model.Number;
                Event.City = model.City;
                Event.Description = model.Description;
                Event.Organizer = model.Organizer;
                Event.PostCode = model.PostCode;
                Event.PhotoFileName = model.PhotoFileName;
                _context.SaveChanges();
                return Ok("updated");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int EventID)
        {
            try
            {
                var Event = _context.Events.Find(EventID);
                if (Event == null)
                {
                    return BadRequest("not found");
                }
                _context.Events.Remove(Event);
                _context.SaveChanges();
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
