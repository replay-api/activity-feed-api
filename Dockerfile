# Use the official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["activity-feed-api.csproj", "activity-feed-api/"]
RUN dotnet restore "activity-feed-api/activity-feed-api.csproj"
COPY . .
WORKDIR "/src/activity-feed-api"
RUN dotnet build "activity-feed-api.csproj" -c Release -o /app/build

# Use the SDK image to publish the app
FROM build AS publish
RUN dotnet publish "activity-feed-api.csproj" -c Release -o /app/publish

# Use the runtime image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "activity-feed-api.dll"]
