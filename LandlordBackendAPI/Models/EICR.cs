using System.ComponentModel.DataAnnotations;

namespace LandlordBackendAPI.Models
{
    public class EICR
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string AdditionalNotes { get; set; } // e.g., access details, tenant info

        public DateTime? PreferredDate { get; set; }

        public string PreferredSlot { get; set; } // "8am-1pm", "1pm-6pm"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string ResidentialUnitType { get; set; } // e.g. "Studio", "1-3 Bedrooms", etc.
        
    }
}
