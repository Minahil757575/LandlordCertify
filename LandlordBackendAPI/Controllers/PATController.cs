using LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandlordBackendAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class PATController : ControllerBase
{
    private readonly AppDbContext _context;

    public PATController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PAT>>> GetAll()
    {
        return await _context.PATs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PAT>> Get(int id)
    {
        var booking = await _context.PATs.FindAsync(id);
        if (booking == null) return NotFound();
        return booking;
    }

    [HttpPost]
    public async Task<ActionResult<PAT>> Post(PAT booking)
    {
        _context.PATs.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, PAT updatedBooking)
    {
        if (id != updatedBooking.Id) return BadRequest();

        _context.Entry(updatedBooking).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var booking = await _context.PATs.FindAsync(id);
        if (booking == null) return NotFound();

        _context.PATs.Remove(booking);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpGet("today")]
    public async Task<ActionResult<IEnumerable<PAT>>> GetTodaySubmissions()
    {
        var today = DateTime.UtcNow.Date;

        var submissions = await _context.EmergencyLightsTests
            .Where(e => e.CreatedAt.Date == today)
            .ToListAsync();

        return Ok(submissions);
    }
}
