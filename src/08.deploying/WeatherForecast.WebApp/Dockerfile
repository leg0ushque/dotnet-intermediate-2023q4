#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WeatherForecast.WebApp/WeatherForecast.WebApp.csproj", "WeatherForecast.WebApp/"]
RUN dotnet restore "WeatherForecast.WebApp/WeatherForecast.WebApp.csproj"
COPY . .
WORKDIR "/src/WeatherForecast.WebApp"
RUN dotnet build "WeatherForecast.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherForecast.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecast.WebApp.dll"]