# Plane-Spotter-Tool
A Web application to assist plane spotters in logging their sightings.

# Requirements
## Technical Requirements
1. The application must be written in C#.
2. It should connect to a SQL Server database.
3. Use an ORM of your choice to communicate with the database.
4. Use an MVVM framework of your choice for the UI.
5. It should be possible to deploy the application by configuring the database connection
and running it.

## Functional Requirements
1. Spotters must be able to record the following information for each sighting:
* Make and model of aircraft.
* Registration of aircraft.
* Location aircraft was seen.
* Date and time aircraft was seen.
2. The application should have the following screens:
* Listing screen showing all aircraft that have been spotted.
* A details screen showing all details of an individual aircraft sighting.
* Form to add a new aircraft sighting.
3. Additionally, the application may allow:
* Remove aircraft sighting from list.
* Edit details of an aircraft sighting.
* Add photo of aircraft (when adding or editing, or both).
* Search for aircraft by Make, Model or Registration (present a filtered list).
