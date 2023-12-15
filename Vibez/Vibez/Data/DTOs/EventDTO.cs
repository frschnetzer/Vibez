using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.DTOs
{
    public class EventDTO
    {
        public string EventName { get; set; } = string.Empty;
        public string CreatorName { get; set; } = string.Empty;
        public int ParticipantCount { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
