﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class EventService : IEventService
    {
        ApplicationDbContext context;

        public EventService(ApplicationDbContext context) => this.context = context;

        public async Task AddEvent(Event newEvent)
        {
            try {
                if (await EventIsValid(newEvent.Id)) {
                    await context.Events.AddAsync(newEvent);
                    await context.SaveChangesAsync();
                }
            } catch (Exception ex) {
                throw new Exception($"Couldn't add event to database. See following exception: {ex}");
            }
        }

        public async Task UpdateEvent(Event newEvent)
        {
            try {
                if (await EventIsValid(newEvent.Id)) {
                    var oldEvent = await context.Events.FirstAsync(x => x.Id == newEvent.Id);

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
            } catch (Exception ex) {
                throw new Exception($"Couldn't update event. See following exception: {ex}");
            }
        }

        public async Task DeleteEventById(int eventId)
        {
            try {
                var deleteEvent = await context.Events.FirstAsync(x => x.Id == eventId);

                context.Events.Remove(deleteEvent);
                await context.SaveChangesAsync();
            } catch (Exception ex) {
                throw new Exception($"Couldn't delete event. See following exception: {ex}");
            }
        }

        public async Task<Event> GetEventById(int eventId)
        {
            try
            {
                return await context.Events.Where(x => x.Id == eventId).FirstAsync();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get events. See following exception: {ex}");
            }
        }

        public async Task<EventDTO> GetEventDTOs(Event newEvent)
        {
            try
            {
                return await context.Events
                    .Where(x => x.Id == newEvent.Id)
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
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get eventDTO. See following exception: {ex}");
            }
        }

        private async Task<bool> EventIsValid(int eventId)
        {
            bool isDuplicate = await context.Events.AnyAsync(x => x.Id == eventId);

            if (!isDuplicate) {
                return false;
            }
            return true;
        }
    }
}
