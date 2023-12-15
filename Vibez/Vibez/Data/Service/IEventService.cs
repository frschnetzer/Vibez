using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IEventService
    {
        Task AddEvent(Event newEvent);
        Task DeleteEventById(int eventId);
        Task<List<Event>> GetAllEvents();
        Task<List<Event>> GetAllUserEvents(string userName);
        Task<Event> GetEventById(int eventId);
        Task<EventDTO> GetEventDTOs(Event newEvent);
        Task UpdateEvent(Event newEvent);
    }
}