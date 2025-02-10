# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./TaskHive.Api/TaskHive.Api.csproj"
RUN dotnet publish "./TaskHive.Api/TaskHive.Api.csproj" -c Release -o /app --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app ./

# Configure environment variables
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Expose port 80
EXPOSE 80

ENTRYPOINT ["dotnet", "TaskHive.Api.dll"]