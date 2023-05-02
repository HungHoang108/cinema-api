# LuxeLane Fullstack


![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

## About
* A simple CinemaAPI using C# and .NET core API. The API allows users to create, read, update, and delete records(cinemas) in a database

### Endpoints:
- GET /cinemas - to get a list of all cinemas
- GET /cinemas/{id} - to retrieve a single cinema with id
- GET /cinemas/{id}/showtimes – to get times when shows start
- POST /cinemas - to create a new cinema
- PUT /cinemas/{id} - to update a specific cinema by ID
- DELETE /cinemas/{id} - to delete a specific cinema by ID

### Showtimes explanation
The function receives four parameters, all of them being integers:
- Id - cinema Id
- open - Hour at which the cinema opens.
- close - Hour at which the cinema closes.
- length - Length of the movie, in minutes.

This endpoint return an array of tuples, each tuple contains (hour, minute) . For example, (19, 30) means 19:30, and (2, 0) means 02:00. The last session in the array cannot end after the cinema closes. Also, the times in the array must be sorted from earliest to latest.
There's also a 15-minute window between a session's end and the beginning of the following one, in order to give enough time for users to take a seat.


## Technology
* Backend: C#, .NET Core API, Entity Framework Core, PostgreSQL, Azure, xUnit testing. 

## How to run the app
- Step 1: Fork and clone the project to your local machine
- Step 2: Cd to cinemaApi repository and install all nescessary nuget packages
- Step 3: In the appsettings.Development.json file, add your local database address to DefaultConnection
- Step 4: run command 'dotnet watch' to run the project

## How to test the app
- Step 1: Cd to cinemaApi.Test repository and install all nescessary nuget packages
- Step 2: run command 'dotnet test'

## Project Structure
```
ApiCinema
├─ .git
├─ .gitignore
├─ ApiCinema.sln
├─ cinemaApi
│  ├─ .gitignore
│  ├─ appsettings.Development.json
│  ├─ cinemaApi.csproj
│  ├─ Controllers
│  │  ├─ BaseController.cs
│  │  └─ CinemaController.cs
│  ├─ Database
│  │  └─ DataContext.cs
│  ├─ DTOs
│  │  └─ CinemaDto.cs
│  ├─ Helpers
│  │  └─ ServiceException.cs
│  ├─ Mapping
│  │  └─ MappingProfile.cs
│  ├─ Middlewares
│  │  └─ ErrorHandlerMiddleware.cs
│  ├─ Models
│  │  ├─ BaseModel.cs
│  │  └─ Cinema.cs
│  ├─ Program.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ Repositories
│  │  ├─ BaseRepo
│  │  │  ├─ BaseRepo.cs
│  │  │  └─ IBaseRepo.cs
│  │  └─ CinemaRepo
│  │     ├─ CinemaRepo.cs
│  │     └─ ICinemaRepo.cs
│  └─ Services
│     ├─ BaseService
│     │  ├─ BaseService.cs
│     │  └─ IBaseService.cs
│     └─ CinemaService
│        ├─ CinemaService.cs
│        └─ ICinemaService.cs
├─ cinemaApi.Test
│  ├─ cinemaApi.Test.csproj
│  ├─ CinemaRepoTests.cs
│  ├─ ShowTimesControllerTests.cs
│  └─ Usings.cs
└─ README.md

```