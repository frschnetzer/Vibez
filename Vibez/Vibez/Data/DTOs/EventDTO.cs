namespace Vibez.Data.DTOs
{
    public class EventDTO
    {
        public string EventName { get; set; } = string.Empty;
        public string CreatorName { get; set; } = string.Empty;
        public int ParticipantCount { get; set; }
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Postcode { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string TimeOnly { get; set; } = string.Empty;
    }
}
