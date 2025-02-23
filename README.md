# taskhive
Basic Task &amp; Project Management Application

This project is work in progress!

## Running application locally

```bash
dotnet clean
dotnet build
cd TaskHive.Api
dotnet run
```

## Running application in docker

First, create a .env file in the root directory with the following content:
```
MSSQL_SA_PASSWORD=YourSaPassword
MSSQL_DEV_PASSWORD=YourPassword
MSSQL_DEV_USER=YOUR_USER
DB_CONNECTION_STRING=YourConnectionString
```

Then, run the following commands:
```bash
docker-compose build
docker-compose up
```

## database setup
If necessary, install the dotnet ef tool globally and run the following commands to create the database schema:

```bash
dotnet tool install --global dotnet-ef
export DB_CONNECTION_STRING="Server=localhost;Database=taskhive;User Id=sa;Password=yourStrong(!)Password;"
cd TaskHive.Infrastructure
dotnet ef database update --startup-project ../TaskHive.Api --project .
```
