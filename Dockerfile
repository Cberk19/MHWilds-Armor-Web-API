FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["MHWilds Armor Web API.csproj", "."]
RUN dotnet restore "MHWilds Armor Web API.csproj"
COPY . .
RUN dotnet publish "MHWilds Armor Web API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MHWilds Armor Web API.dll"]