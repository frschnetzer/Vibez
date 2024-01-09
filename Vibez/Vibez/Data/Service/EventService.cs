using Microsoft.EntityFrameworkCore;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class EventService : IEventService
    {
        ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adding new event to database
        /// </summary>
        /// <param name="newEvent">Event to add</param>
        /// <exception cref="Exception">Throws when event could not be added</exception>
        public async Task AddEvent(Event newEvent)
        {
            try
            {
                if(await EventIsValid(newEvent.EventId))
                {
                    await _context.Events.AddAsync(newEvent);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't add event to database. See following exception: {ex}");
            }
        }

        /// <summary>
        /// Editing an existing event from database
        /// </summary>
        /// <param name="newEvent">To edit event</param>
        /// <exception cref="Exception">Throws when the database throws an error</exception>
        public async Task UpdateEvent(Event newEvent)
        {
            try
            {
                if(await EventIsValid(newEvent.EventId))
                {
                    var oldEvent = await _context.Events.Where(x => x.EventId == newEvent.EventId).FirstAsync();

                    oldEvent.EventName = newEvent.EventName;
                    oldEvent.CreatorName = "HalloHallo";
                    oldEvent.LocationName = newEvent.LocationName;
                    oldEvent.Date = newEvent.Date;
                    oldEvent.Notes = newEvent.Notes;
                    oldEvent.ParticipantCount = newEvent.ParticipantCount;
                    oldEvent.CordinatesLatitude = newEvent.CordinatesLatitude;
                    oldEvent.CordinatesLongitude = newEvent.CordinatesLongitude;
                    oldEvent.IdentityUsers = newEvent.IdentityUsers;

                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't update event. See following exception: {ex}");
            }
        }

        public async Task DeleteEventById(int eventId)
        {
            try
            {
                var deleteEvent = await _context.Events.Where(x => x.EventId == eventId).FirstAsync();

                _context.Events.Remove(deleteEvent);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't delete event. See following exception: {ex}");
            }
        }

        public async Task<Event> GetEventById(int eventId)
        {
            try
            {
                return await _context.Events.Where(x => x.EventId == eventId).FirstAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get event by id. See following exception: {ex}");
            }
        }

        public async Task<List<Event>> GetAllEvents()
        {
            try
            {
                return await _context.Events.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get events. See following exception: {ex}");
            }
        }

        public async Task<EventDTO> GetEventDTOs(Event newEvent)
        {
            try
            {
                return await _context.Events
                    .Where(x => x.EventId == newEvent.EventId)
                    .Select(x => new EventDTO
                    {
                        EventName = newEvent.EventName,
                        CreatorName = newEvent.CreatorName,
                        LocationName = newEvent.LocationName,
                        Notes = newEvent.Notes,
                        Date = newEvent.Date,
                        ParticipantCount = newEvent.ParticipantCount
                    }).FirstAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get eventDTO. See following exception: {ex}");
            }
        }

        private async Task<bool> EventIsValid(int eventId)
        {
            bool isDuplicate = await _context.Events.AnyAsync(x => x.EventId == eventId);

            if(eventId > 0)
            {

                if(isDuplicate)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if(isDuplicate)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
