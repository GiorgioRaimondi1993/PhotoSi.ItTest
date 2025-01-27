#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7006
EXPOSE 7007

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PhotoSi.Users.API/PhotoSi.Users.API.csproj", "src/PhotoSi.Users.API/"]
COPY ["src/PhotoSi.Users.Infrastracture/PhotoSi.Users.Infrastracture.csproj", "src/PhotoSi.Users.Infrastracture/"]
COPY ["src/PhotoSi.Users.Application/PhotoSi.Users.Application.csproj", "src/PhotoSi.Users.Application/"]
RUN dotnet restore "./src/PhotoSi.Users.API/PhotoSi.Users.API.csproj"
COPY . .
WORKDIR "/src/src/PhotoSi.Users.API"
RUN dotnet build "./PhotoSi.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PhotoSi.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoSi.Users.API.dll"]