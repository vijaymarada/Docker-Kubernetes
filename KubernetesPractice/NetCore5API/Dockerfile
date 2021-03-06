#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_URLS http://*:80
# Enable docker - Start
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT=Development
# Enable docker - End
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetCore5API.csproj", "."]
RUN dotnet restore "./NetCore5API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NetCore5API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore5API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore5API.dll"]