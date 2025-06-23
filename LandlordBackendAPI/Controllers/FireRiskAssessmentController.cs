using LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandlordBackendAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class FireRiskAssessmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public FireRiskAssessmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FireRiskAssessment>>> GetAll()
    {
        return await _context.FireRiskAssessments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FireRiskAssessment>> Get(int id)
    {
        var booking = await _context.FireRiskAssessments.FindAsync(id);
        if (booking == null) return NotFound();
        return booking;
    }

    [HttpPost]
    public async Task<ActionResult<FireRiskAssessment>> Post(FireRiskAssessment booking)
    {
        _context.FireRiskAssessments.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, FireRiskAssessment updatedBooking)
    {
        if (id != updatedBooking.Id) return BadRequest();

        _context.Entry(updatedBooking).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var booking = await _context.FireRiskAssessments.FindAsync(id);
        if (booking == null) return NotFound();

        _context.FireRiskAssessments.Remove(booking);
        await _context.SaveChangesAsync();
            return NoContent();
    }
    [HttpGet("today")]
    public async Task<ActionResult<IEnumerable<FireRiskAssessment>>> GetTodaySubmissions()
    {
        var today = DateTime.UtcNow.Date;

        var submissions = await _context.EmergencyLightsTests
            .Where(e => e.CreatedAt.Date == today)
            .ToListAsync();

        return Ok(submissions);
    }
}
