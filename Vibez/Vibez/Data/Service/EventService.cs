using Microsoft.EntityFrameworkCore;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class EventService : IEventService
    {
        ApplicationDbContext context;

        private ApplicationUserService _userService;

        public EventService(ApplicationDbContext context)
        {
            // TODO: warum nicht _context??
            // TODO: richtige reihenfolge der Methoden beachten: Get, Add, Edit, Delete, validation
            // TODO: implement upcoming and past event list of a user
            this.context = context;
            _userService = new(context);
        }

        public async Task AddEvent(Event newEvent)
        {
            try
            {
                if (await EventIsValid(newEvent.EventId))
                {
                    await context.Events.AddAsync(newEvent);
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't add event to database. See following exception: {ex}");
            }
        }

        public async Task UpdateEvent(Event newEvent)
        {
            try
            {
                if (await EventIsValid(newEvent.EventId))
                {
                    var oldEvent = await context.Events.FirstAsync(x => x.EventId == newEvent.EventId);

                    oldEvent.EventName = newEvent.EventName;
                    oldEvent.CreatorName = newEvent.CreatorName;
                    oldEvent.LocationName = newEvent.LocationName;
                    oldEvent.Date = newEvent.Date;
                    oldEvent.Notes = newEvent.Notes;
                    oldEvent.ParticipantCount = newEvent.ParticipantCount;
                    oldEvent.CordinatesLatitude = newEvent.CordinatesLatitude;
                    oldEvent.CordinatesLongitude = newEvent.CordinatesLongitude;
                    oldEvent.ApplicationUsers = newEvent.ApplicationUsers;

                    await context.SaveChangesAsync();
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
                var deleteEvent = await context.Events.FirstAsync(x => x.EventId == eventId);

                context.Events.Remove(deleteEvent);
                await context.SaveChangesAsync();
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
                return await context.Events.Where(x => x.EventId == eventId).FirstAsync();
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
                return await context.Events.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get events. See following exception: {ex}");
            }
        }

        public async Task<List<Event>> GetAllUserEvents(string userName)
        {
            try
            {
                var user = await _userService.GetApplicationUserByEmail(userName);

                return await context.Events
                    .Where(x => x.CreatorName == userName || x.ApplicationUsers.Any(u => u.UserName == userName))
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not get all events: {ex.Message}");
            }
        }

        public async Task<EventDTO> GetEventDTOs(Event newEvent)
        {
            try
            {
                return await context.Events
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
            bool isDuplicate = await context.Events.AnyAsync(x => x.EventId == eventId);

            if(isDuplicate)
            {
                return false;
            }
            return true;
        }
    }
}
