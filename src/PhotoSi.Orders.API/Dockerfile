#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7026
EXPOSE 7027

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PhotoSi.Orders.API/PhotoSi.Orders.API.csproj", "src/PhotoSi.Orders.API/"]
COPY ["src/PhotoSi.Orders.Infrastracture/PhotoSi.Orders.Infrastracture.csproj", "src/PhotoSi.Orders.Infrastracture/"]
COPY ["src/PhotoSi.Orders.Application/PhotoSi.Orders.Application.csproj", "src/PhotoSi.Orders.Application/"]
RUN dotnet restore "./src/PhotoSi.Orders.API/PhotoSi.Orders.API.csproj"
COPY . .
WORKDIR "/src/src/PhotoSi.Orders.API"
RUN dotnet build "./PhotoSi.Orders.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PhotoSi.Orders.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoSi.Orders.API.dll"]