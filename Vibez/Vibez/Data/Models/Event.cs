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
        public string LocationName { get; set; } = string.Empty;

        [Required]
        public double CordinatesLongitude { get; set; }

        [Required]
        public double CordinatesLatitude { get; set; }

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
