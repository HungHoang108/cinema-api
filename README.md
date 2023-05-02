# CinemaApi


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

### About Showtimes
The function receives four parameters, all of them being integers:
- Id - cinema Id
- open - Hour at which the cinema opens.
- close - Hour at which the cinema closes.
- length - Length of the movie, in minutes.

The endpoint returns an array of tuples where each tuple includes hour and minute values. For instance, (19, 30) represents 19:30. 
The last session in the array must not end later than the cinema's closing time. 
The array is sorted from earliest to latest and a 15-minute break is required between the end of one session and the start of the next one to ensure sufficient time for the audience to settle in.


## Technology
* Backend: C#, .NET Core API, Entity Framework Core, PostgreSQL, Azure, xUnit testing. 

## Run the app with Docker
Ensure that you have Docker Desktop installed. Then run below commands on the terminal:
- docker pull hunghoang108/cinemaapi
- docker run -p 5000:80 cinemaapi:1.0.0

After the docker is run. you can access to the swagger ui with http://localhost:5000/swagger/index.html

Note: There will be some error executing crud operations in case of using Docker

## Run the app with Github
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