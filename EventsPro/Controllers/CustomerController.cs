using EventsPro.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// This is the change in branch A 
namespace EventsPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _context.Customer.ToList();
                if (users.Count == 0)
                {
                    return NotFound("No customers");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{CustomerID}")]


    }
}
