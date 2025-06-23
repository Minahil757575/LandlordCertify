using System.ComponentModel.DataAnnotations;

namespace LandlordBackendAPI.Models
{
    public class FAQ
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public string PageName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
