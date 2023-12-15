# Vibez

## Prerequisits
- .NET: 7.0.
- Windows: 11
- Docker: 24.0.6.
- Docker-Compose: 2.23.0.
- Blazor Server App
- Sql Server: 2022

## Structure
### Backend
### DB Context:
- DbContext created with EF-Core. Changes are DbSets and OnModelCreating Method.
- OnModelCreating creates a intermediate table for ApplicationUser and Events table

### Models:
- ApplicationUser model was newly created and added two new properties: Nickname and List<Events>.
- Event model was newly created with following properties: Id, EventName, CreatorName, ParticipantCount, LocationName, CoorinatesLongitude, CoordinatesLatitude, Notes, Date and List<ApplicationUser>.
- The intermediate table between Events and ApplicationUser was automatically created by EF-Core.

### DTOs:
- ApplicationUserDto and EventDto

### Service:
- ApplicationService and EventService with Interfaces. Both servies have database statements (add, edit, delete, get,..).
- every access to the database and all calculations are located in the services.
  
### Frontend
