using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IEventService
    {
        Task AddEvent(Event newEvent);
        Task DeleteEventById(int eventId);
        Task UpdateEvent(Event newEvent);
    }
}