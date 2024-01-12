using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.DTOs
{
    public class EventDTO
    {
        public string EventName { get; set; } = string.Empty;
        public string CreatorName { get; set; } = string.Empty;
        public int ParticipantCount { get; set; }
        public string City { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public int Postcode { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string TimeOnly { get; set; } = string.Empty;
    }
}
