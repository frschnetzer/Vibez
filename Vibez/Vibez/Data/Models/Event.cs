using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;

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

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string EventTime { get; set; } = string.Empty;

        public List<IdentityUser> IdentityUsers { get; set; } = new List<IdentityUser>();
    }
}
