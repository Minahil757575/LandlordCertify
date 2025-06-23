using LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandlordBackendAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class FireExtinguisherController : ControllerBase
{
    private readonly AppDbContext _context;

    public FireExtinguisherController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FireExtinguisher>>> GetAll()
    {
        return await _context.FireExtinguishers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FireExtinguisher>> Get(int id)
    {
        var booking = await _context.FireExtinguishers.FindAsync(id);
        if (booking == null) return NotFound();
        return booking;
    }

    [HttpPost]
    public async Task<ActionResult<FireExtinguisher>> Post(FireExtinguisher booking)
    {
        _context.FireExtinguishers.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, FireExtinguisher updatedBooking)
    {
        if (id != updatedBooking.Id) return BadRequest();

        _context.Entry(updatedBooking).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var booking = await _context.FireExtinguishers.FindAsync(id);
        if (booking == null) return NotFound();

        _context.FireExtinguishers.Remove(booking);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpGet("today")]
    public async Task<ActionResult<IEnumerable<FireExtinguisher>>> GetTodaySubmissions()
    {
        var today = DateTime.UtcNow.Date;

        var submissions = await _context.EmergencyLightsTests
            .Where(e => e.CreatedAt.Date == today)
            .ToListAsync();

        return Ok(submissions);
    }
}
