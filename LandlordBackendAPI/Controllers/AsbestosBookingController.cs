using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandlordBackendAPI.Data;
using LandlordBackendAPI.Models;

namespace LandlordBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsbestosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsbestosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Asbestos
        [HttpPost]
        public async Task<IActionResult> PostAsbestosBooking([FromBody] AsbestosBooking booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            booking.CreatedAt = DateTime.UtcNow;

            _context.AsbestosBookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        // GET: api/Asbestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsbestosBooking>>> GetAllAsbestosBookings()
        {
            return await _context.AsbestosBookings
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        // GET: api/Asbestos/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<AsbestosBooking>>> GetTodaysAsbestosBookings()
        {
            var today = DateTime.UtcNow.Date;

            var todaysBookings = await _context.AsbestosBookings
                .Where(b => b.CreatedAt.Date == today)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return Ok(todaysBookings);
        }
    }
}
