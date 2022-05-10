#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/FileServer.API/FileServer.API.csproj", "Services/FileServer.API/"]
COPY ["Services/ModelLibrary/ModelLibrary.csproj", "Services/ModelLibrary/"]
RUN dotnet restore "Services/FileServer.API/FileServer.API.csproj"
COPY . .
WORKDIR "/src/Services/FileServer.API"
RUN dotnet build "FileServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileServer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileServer.API.dll"]