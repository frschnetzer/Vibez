﻿using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IEventService
    {
        Task AddEvent(Event newEvent);
        Task DeleteEventById(int eventId);
        Task<List<Event>> GetAllEvents();
        Task<List<Event>> GetAllUpcomingEvents(string username);
        Task<List<Event>> GetAllPastEvents(string username);
        Task<Event> GetEventById(int eventId);
        Task<EventDTO> GetEventDTOs(Event newEvent);
        Task<List<Event>> GetEventsFromUser(ApplicationUser user);
        Task UpdateEvent(Event newEvent);
        Task<List<Event>> GetAllUpcomingEventsForOneUser(string username);
    }
}