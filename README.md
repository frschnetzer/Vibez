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
#### DB Context:
- DbContext created with EF-Core. Changes are DbSets and OnModelCreating Method.
- OnModelCreating creates a intermediate table for ApplicationUser and Events table

#### Models:
- ApplicationUser model was newly created and added two new properties: Nickname and List<Events>.
- Event model was newly created with following properties: Id, EventName, CreatorName, ParticipantCount, LocationName, CoorinatesLongitude, CoordinatesLatitude, Notes, Date and List<ApplicationUser>.
- The intermediate table between Events and ApplicationUser was automatically created by EF-Core.

-The models changed since the this README was first written:
-The ApplicationUser doesn't have a Nickname anymore and he has a List<Friends> as property.
-The Friends model has a Id, FriendEmail then a ApplicationUserId and A Applicationuser thats it.
-Event also has some changes to the properties, there is no Cordinates anymore and it now has City, Address and Postcode.

#### DTOs:
- ApplicationUserDto and EventDto

#### Service:
- ApplicationService and EventService with Interfaces. Both servies have database statements (add, edit, delete, get,..).
- every access to the database and all calculations are located in the services.

- Now there is also a FriendService with a Interface. This Service also have the same methods as the EventServic etc.
     
### Frontend
#### wwwroot
-  contains all pngs and Icons
#### Pages
- CreateParyView

## Email
### Technologies
- MailKit NuGet
- SMTP Server name (Gmail)
- Port: 587 TLS
- Email Address of sender
- Email Address of reciever
- unlock password for App in Google Account (Account -> Security -> App Passwords)

### Code
- see Vibez_Email.pdf

## Maps
### Technologies
- Google API is not open source so we choose IFRAME Tool

### Functionality
- address of event should give parameters to the IFRAME
- Then the location of the event will be shown in a map 
- source: Vibez_Maps.pdf

## Mulitlanguages
### Functionality
- through "CultureInfo" we can change the language of the website.
- we need .txt files for instructions e.g. en-US or de-DE
- source: Vibez_MultiLanguage.pdf
