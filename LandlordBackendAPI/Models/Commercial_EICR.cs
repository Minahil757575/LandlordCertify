using System.ComponentModel.DataAnnotations;

namespace LandlordBackendAPI.Models
{
    public class Commercial_EICR
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CompanyName { get; set; } // New field for commercial purposes

        [Required]
        public string Address { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string AdditionalNotes { get; set; }

        public DateTime? PreferredDate { get; set; }

        public string PreferredSlot { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string ResidentialUnitType { get; set; } // e.g. "Studio", "1-3 Bedrooms", etc
    }
}
