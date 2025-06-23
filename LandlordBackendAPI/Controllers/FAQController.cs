using LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using LandlordBackendAPI.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FAQController : ControllerBase
{
    private readonly AppDbContext _context;

    public FAQController(AppDbContext context)
    {
        _context = context;
    }

    // GET all FAQs for a page
    [HttpGet("{pageName}")]
    public async Task<ActionResult<IEnumerable<FAQ>>> GetFAQs(string pageName)
    {
        return await _context.FAQs
            .Where(f => f.PageName == pageName)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }

    // POST new FAQ
    [HttpPost]
    public async Task<IActionResult> PostFAQ(FAQ faq)
    {
        _context.FAQs.Add(faq);
        await _context.SaveChangesAsync();
        return Ok(faq);
    }

    // PUT update FAQ
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFAQ(int id, FAQ updatedFAQ)
    {
        var faq = await _context.FAQs.FindAsync(id);
        if (faq == null) return NotFound();

        faq.Question = updatedFAQ.Question;
        faq.Answer = updatedFAQ.Answer;
        faq.PageName = updatedFAQ.PageName;

        await _context.SaveChangesAsync();
        return Ok(faq);
    }

    // DELETE FAQ
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFAQ(int id)
    {
        var faq = await _context.FAQs.FindAsync(id);
        if (faq == null) return NotFound();

        _context.FAQs.Remove(faq);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
