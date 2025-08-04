# Use the .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy project files and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish the app to the /app/out directory
RUN dotnet publish -c Release -o /app/out

# Optional: Debug output
RUN echo "Published output:" && ls -R /app/out

# Use the .NET 8 runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/out ./

# Expose a port if you're running a web server (optional, can be removed)
EXPOSE 8080

# Start the bot
ENTRYPOINT ["dotnet", "SwizzBotDisco.dll"]
