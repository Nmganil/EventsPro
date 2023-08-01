using EventsPro.Data;
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

    }
}
