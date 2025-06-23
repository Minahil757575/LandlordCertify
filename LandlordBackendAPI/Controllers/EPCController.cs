using Microsoft.AspNetCore.Mvc;
using LandlordBackendAPI.Models;
using LandlordBackendAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace LandlordBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Controller name is EICR => api/EICR
    public class EPCController : ControllerBase
    {

        private readonly AppDbContext _context;

        public EPCController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/EICR
        [HttpPost]
        public async Task<IActionResult> PostEicrBooking([FromBody] EPC booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            booking.CreatedAt = DateTime.UtcNow;

            _context.EPCs.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }


        // GET: api/EICR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EPC>>> GetEicrBookings()
        {
            return await _context.EPCs.ToListAsync();
        }
        // GET: api/EICR/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<EPC>>> GetTodaysEicrBookings()
        {
            var today = DateTime.UtcNow.Date;

            var bookingsToday = await _context.EPCs
                .Where(b => b.CreatedAt.Date == today)
                .ToListAsync();

            return Ok(bookingsToday);
        }


    }
}
