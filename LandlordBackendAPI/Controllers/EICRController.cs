using Microsoft.AspNetCore.Mvc;
using LandlordBackendAPI.Models;
using LandlordBackendAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace LandlordBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Controller name is EICR => api/EICR
    public class EICRController : ControllerBase
    {
      
            private readonly AppDbContext _context;

            public EICRController(AppDbContext context)
            {
                _context = context;
            }

            // POST: api/EICR
            [HttpPost]
            public async Task<IActionResult> PostEicrBooking([FromBody] EICR booking)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                booking.CreatedAt = DateTime.UtcNow;

                _context.EicrBookings.Add(booking);
                await _context.SaveChangesAsync();

                return Ok(booking);
            }


            // GET: api/EICR
            [HttpGet]
            public async Task<ActionResult<IEnumerable<EICR>>> GetEicrBookings()
            {
                return await _context.EicrBookings.ToListAsync();
            }
        // GET: api/EICR/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<EICR>>> GetTodaysEicrBookings()
        {
            var today = DateTime.UtcNow.Date;

            var bookingsToday = await _context.EicrBookings
                .Where(b => b.CreatedAt.Date == today)
                .ToListAsync();

            return Ok(bookingsToday);
        }


    }
}
