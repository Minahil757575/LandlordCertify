using LandlordBackendAPI.Models;
using LandlordBackendAPI.Models.LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandlordBackendAPI;
using LandlordBackendAPI.Data;

namespace LandlordBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommercialGasCertificateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommercialGasCertificateController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/CommercialGasCertificate
        [HttpPost]
        public async Task<IActionResult> PostBooking([FromBody] CommercialGasCertificate booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.CommercialGasCertificates.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking); // 200 OK with saved object
        }

        // GET: api/CommercialGasCertificate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialGasCertificate>>> GetBookings()
        {
            return await _context.CommercialGasCertificates.ToListAsync();
        }

        // Optional: GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CommercialGasCertificate>> GetBooking(int id)
        {
            var booking = await _context.CommercialGasCertificates.FindAsync(id);

            if (booking == null)
                return NotFound();

            return booking;
        }
        // GET: api/CommercialGasCertificate/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<CommercialGasCertificate>>> GetTodaysCommercialGasBookings()
        {
            var today = DateTime.UtcNow.Date;

            var bookingsToday = await _context.CommercialGasCertificates
                .Where(b => b.CreatedAt.Date == today)
                .ToListAsync();

            return Ok(bookingsToday);
        }

    }
}
