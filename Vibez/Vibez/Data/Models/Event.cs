using System.ComponentModel.DataAnnotations;
using Vibez.Validation;

namespace Vibez.Data.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please enter a Event Name")]
        [StringLength(100)]
        public string EventName { get; set; } = string.Empty;

        public string CreatorName { get; set; } = string.Empty;

        public int ParticipantCount { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Street")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Postcode")]
        public string Postcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter some Notes")]
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plese enter Time")]

        [DateValidationAttribute(ErrorMessage = "Date can not be in past")]
        public DateTime Date { get; set; } = DateTime.Now;

        public string EventTime { get; set; } = string.Empty;

        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}