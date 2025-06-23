using LandlordBackendAPI.Data;
using LandlordBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LandlordBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactFormController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/ContactForm
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContactForm(Contact contactForm)
        {
            _context.ContactForms.Add(contactForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactForm), new { id = contactForm.Id }, contactForm);
        }

        // GET: api/ContactForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactForms()
        {
            return await _context.ContactForms.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        // GET: api/ContactForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactForm(int id)
        {
            var contactForm = await _context.ContactForms.FindAsync(id);

            if (contactForm == null)
                return NotFound();

            return contactForm;
        }
    }
}
