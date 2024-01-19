﻿using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateEvent(Event newEvent)
        {
            try
            {
                if(await EventIsValid(newEvent.EventId))
                {
                    var oldEvent = await _context.Events.Where(x => x.EventId == newEvent.EventId).FirstAsync();

                    oldEvent.EventName = newEvent.EventName;
                    oldEvent.City = newEvent.City;
                    oldEvent.Address = newEvent.Address;
                    oldEvent.Postcode = newEvent.Postcode;
                    oldEvent.Date = newEvent.Date;
                    oldEvent.Notes = newEvent.Notes;
                    oldEvent.ParticipantCount = newEvent.ParticipantCount;
                    oldEvent.ApplicationUsers = newEvent.ApplicationUsers;

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

        public async Task<List<Event>> GetEventsFromUser(ApplicationUser user)
        {
            try
            {
                return await _context.Events
                    .Where(e => e.CreatorName == user.UserName)
                    .OrderByDescending(x => x.Date)
                    .Include(nameof(Event.ApplicationUsers))
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get event by user. See following exception: {ex}");
            }
        }

        public async Task<Event> GetEventById(int eventId)
        {
            try
            {
                return await _context.Events
                    .Where(x => x.EventId == eventId)
                    .Include(nameof(Event.ApplicationUsers))
                    .FirstAsync();
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
                return await _context.Events
                    .OrderByDescending(x => x.Date)
                    .Include(nameof(Event.ApplicationUsers))
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get events. See following exception: {ex}");
            }
        }

        public async Task<List<Event>> GetAllUpcomingEvents(string username)
        {
            try
            {
                return await _context.Events
                    .Where(e => e.Date >= DateTime.Now && e.CreatorName == username)
                    .OrderByDescending(x => x.Date)
                    .Include(nameof(Event.ApplicationUsers))
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get upcoming events. See following exception: {ex}");
            }
        }

        public async Task<List<Event>> GetAllUpcomingEventsForOneUser(string username)
        {
            try
            {
                return await _context.Events
                    .Include(nameof(Event.IdentityUsers))
                    .Where(e => e.Date >= DateTime.Now && e.IdentityUsers
                        .Any(u => u.UserName  == username))
                    .OrderByDescending(x => x.Date)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get upcoming events. See following exception: {ex}");
            }
        }

        public async Task<List<Event>> GetAllPastEvents(string username)
        {
            try
            {
                return await _context.Events
                    .Where(e => e.Date <= DateTime.Now && e.CreatorName == username)
                    .OrderByDescending(x => x.Date)
                    .Include(nameof(Event.ApplicationUsers))
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get past events. See following exception: {ex}");
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
                        City = newEvent.City,
                        Address = newEvent.Address,
                        Postcode = newEvent.Postcode,
                        Notes = newEvent.Notes,
                        Date = newEvent.Date,
                        TimeOnly = newEvent.EventTime,
                        ParticipantCount = newEvent.ParticipantCount
                    })
                    .OrderByDescending(x => x.Date)
                    .FirstAsync();
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
