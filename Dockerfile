FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["MHWildsArmorWebAPI/MHWildsArmorWebAPI.csproj", "MHWildsArmorWebAPI/"]
RUN dotnet restore "MHWildsArmorWebAPI/MHWildsArmorWebAPI.csproj"
COPY . .
WORKDIR "/src/MHWildsArmorWebAPI"
RUN dotnet publish "MHWildsArmorWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MHWildsArmorWebAPI.dll"]