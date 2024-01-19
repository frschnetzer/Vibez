using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string CreatorName { get; set; } = string.Empty;

        public int ParticipantCount { get; set; }

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Postcode { get; set; } = string.Empty;

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string EventTime { get; set; } = string.Empty;

        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
