using Microsoft.AspNetCore.Identity;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IEventService
    {
        Task AddEvent(Event newEvent);
        Task DeleteEventById(int eventId);
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<EventDTO> GetEventDTOs(Event newEvent);
        Task<List<Event>> GetEventsFromUser(IdentityUser user);
        Task UpdateEvent(Event newEvent);
    }
}