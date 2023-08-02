using EventsPro.Data;
using EventsPro.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
       private readonly AppDbContext _Context;

        public OrganizerController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]

        public IActionResult get()
        {
            try
            {
                var host = _Context.Organizer.ToList();
                if (host.Count == null)
                {
                    return NotFound("No organizer found");
                }
                return Ok(host);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{organizerID}")]
        public IActionResult get(int organizerID)
        {
            try
            {
                var host = _Context.Organizer.Find(organizerID);
                if (host == null)
                {
                    return NotFound($"organiser not found with ID {organizerID}");
                }
                return Ok(host);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]

        public IActionResult post(Organizer model)
        {
            try
            {
                _Context.Organizer.Add(model);
                _Context.SaveChanges();
                return Ok("Added new organizer");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public IActionResult put(Organizer model)
        {
           if(model==null || model.organizerID == 0)
            {
                if(model==null)
                {
                    return BadRequest("invalid input");
                }
                else if (model.organizerID == 0)
                {
                    return BadRequest("invalid input");
                }
                
            }
            try
            {
                var host = _Context.Organizer.Find(model.organizerID);
                if (host == null)
                {
                    return NotFound("Organiser changes not found");
                }
                host.organizerName = model.organizerName;
                host.organizerNumber = model.organizerNumber;
                host.organizerEmail = model.organizerEmail;
                _Context.SaveChanges();
                return Ok(host);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


           
        }

        [HttpDelete]

        public IActionResult delete(int organizerID)
        {
            try
            {
                var host = _Context.Organizer.Find(organizerID);
                if (host == null)
                {
                    return NotFound("Orgainizer not found");
                }
                _Context.Organizer.Remove(host);
                _Context.SaveChanges();
                return Ok("Organizer deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

    }
}
