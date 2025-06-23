using LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LandlordBackendAPI.Data;

namespace LandlordBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommercialEICRController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommercialEICRController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/CommercialEICR
        [HttpPost]
        public async Task<IActionResult> PostCommercialEicrBooking([FromBody] Commercial_EICR booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            booking.CreatedAt = DateTime.UtcNow;

            _context.CommercialEICRs.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        // GET: api/CommercialEICR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commercial_EICR>>> GetAllCommercialEicrBookings()
        {
            return await _context.CommercialEICRs
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        // GET: api/CommercialEICR/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<Commercial_EICR>>> GetTodaysCommercialEicrBookings()
        {
            var today = DateTime.UtcNow.Date;

            var todaysBookings = await _context.CommercialEICRs
                .Where(b => b.CreatedAt.Date == today)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return Ok(todaysBookings);
        }
    }
}
