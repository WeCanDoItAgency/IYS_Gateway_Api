# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER root
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=80 \
    ASPNETCORE_PRELOAD=1

EXPOSE 80

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/IYS.Gateway.Api/IYS.Gateway.Api.csproj", "src/IYS.Gateway.Api/"]
COPY ["src/IYS.Gateway.Application/IYS.Gateway.Application.csproj", "src/IYS.Gateway.Application/"]
COPY ["src/IYS.Gateway.Domain/IYS.Gateway.Domain.csproj", "src/IYS.Gateway.Domain/"]
COPY ["src/IYS.Gateway.Infrastructure/IYS.Gateway.Infrastructure.csproj", "src/IYS.Gateway.Infrastructure/"]
RUN dotnet restore "./src/IYS.Gateway.Api/IYS.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/src/IYS.Gateway.Api"
RUN dotnet build "./IYS.Gateway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IYS.Gateway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IYS.Gateway.Api.dll"]