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

Beware that the api docker container needs a valid dev certificate on the host machine. If you don't have one, you can create one by running the following command:
```bash
dotnet dev-certs https --clean # remove any existing certificates
dotnet dev-certs https -ep "./aspnetcore-devcert.pfx" -p "YourPassword"
```

Double check the appsettings.Development.json file whether the certificate password is correct.
It should look something like this:
```json
{
  "Kestrel": {
    "EndPoints": {
      "Https": {
        "Url": "https://*:443",
        "Certificate": {
          "Path": "/https/aspnetcore-devcert.pfx",
          "Password": "YourPassword"
        }
      }
    }
  }
}
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
