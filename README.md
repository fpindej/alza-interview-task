# Alza interview task

## Pre-requisites

1. [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to run the project in IDE
2. [SQL Server 2022](https://go.microsoft.com/fwlink/p/?linkid=2215158&clcid=0x409&culture=en-us&country=us) to host the datase server locally.
    > 💡 Using a dockerized container instead is highly recommended.
3. [Docker](https://www.docker.com/products/docker-desktop/) to run the database and application in container
    > Feel free to use any supported docker daemon (e.g. Rancher Desktop etc.)
4. IDE (e.g. Visual Studio Code, Visual Studio 2022, Jetbrains Rider...)

## Initial run

1. Run the database server:
    - for running in Docker:
        ```sh
        docker compose -f docker-compose.local.yml up alza-db
        ```
    - if running the database server locally, simply run the application in `Development` configuration, the connection string is already there

2. Open IDE and open the solution

3. Start the application:
    - from IDE:
        - press `Run`
    - from terminal:
        - navigate to `./src/Alza.Api`
        - execute this command:
        ```sh
        dotnet run
        ```

    > Run the application in `Http-Development` configuration, this automatically applies the migrations to the database on local environment. The connection string is already present in `appsettings.Development.json`.

4. Open the web browser

5. Navigate to `http://localhost:5147/swagger/`

6. Use the application

## Running the tests

1. Run the tests from the IDE via the Test Explorer

## Swapping between the database and mock data

The project has an implementation of `MockDataRepository` with some in-memory `MockData`.

If You want to use the mock data instead of the database data for the development, simply change the registration in `./src/Alza.Persistence/Extensions/ServiceCollectionExtensions.cs` from this:
    
```cs
services.AddScoped<IProductRepository, ProductRepository>();
```

to this:
    
```cs
services.AddScoped<IProductRepository, MockProductRepository>();
```
    


## Solution structure

The solution structure is inspired by the concept of clean architecture and DDD. Dependencies always go "inwards" towards the lowest layer of the solution, that being `Alza.Domain`. This keeps everything nicely structured, organized and well maintainable.

See the [Solution projects](#solution-projects) for more information about each assembly.

## Solution projects

### Alza.Api

An ASP.NET Core Web API project exposing an API as HTTP endpoints to work with the Product entity.

### Alza.Domain

Holds the domain objects (in this instance just one object) to make the required entity contractable by the business capabilities. It's very simple in here, but it's pretty much working grounds of the concept of separation of concerns.

### Alza.Application

A layer serving to abstracting the implementations (services, repositories etc.) from their respective implementations. This also contributes to separating concerns.

> Normally I would also write Service/Handler classes instead of using repositories only, but this example is simple enough and there's no need to overcomplicate it with more overhead when not needed yet.
    
### Alza.Persistence

Data layer operating with the database. This entire layer is responsible for the implementation of repositories, communicating with the database, data seeding, configuring the database and registration of data related dependencies.

- used ORM framework is EF Core 8

### Alza.MockInfrastructure

A shared project between the actual solution and tests. Holds static data in a C# collection type (list) and provides a mock repository with simplified behaviour compared to the database repository.

### Alza.UnitTests

An xUnit project with some basic controller tests, as per the assignment.

