namespace LandlordBackendAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace LandlordBackendAPI.Models
    {
        public class CommercialGasCertificate
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; }

            [Required]
            public string BusinessName { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Phone { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            public string Postcode { get; set; }

            public DateTime? PreferredDate { get; set; }

            public string TimeSlot { get; set; }

            public string AdditionalNotes { get; set; }
            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            [Required]
            public string ResidentialUnitType { get; set; } // e.g. "Studio", "1-3 Bedrooms", etc

        }
    }

}
