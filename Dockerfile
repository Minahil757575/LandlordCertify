# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . ./
WORKDIR /src/LandlordBackendAPI
RUN dotnet restore "LandlordBackendAPI.csproj"
RUN dotnet publish "LandlordBackendAPI.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LandlordBackendAPI.dll"]
