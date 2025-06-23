using System.ComponentModel.DataAnnotations;

namespace LandlordBackendAPI.Models
{
    public class PAT
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime PreferredDate { get; set; }
        public string PreferredSlot { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Add this line
        [Required]
        public string ResidentialUnitType { get; set; } // e.g. "Studio", "1-3 Bedrooms", etc

    }
}
