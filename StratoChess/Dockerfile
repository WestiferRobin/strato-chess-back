# Use the official .NET 7 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copy the .csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the application source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET 7 runtime image as the final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/out ./

# Expose the port your application listens on
EXPOSE 80

# Define the entry point for your application
ENTRYPOINT ["dotnet", "StratoChess.dll"]
