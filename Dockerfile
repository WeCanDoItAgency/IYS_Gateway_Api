# ═══════════════════════════════════════════════════════════════
# IYS Gateway API — Multi-stage Dockerfile
# Base: .NET 10 SDK (build) → .NET 10 ASP.NET Runtime (publish)
# ═══════════════════════════════════════════════════════════════

# ─── Build Stage ─────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# NuGet restore önce (cache layer)
COPY src/IYS.Gateway.Domain/IYS.Gateway.Domain.csproj src/IYS.Gateway.Domain/
COPY src/IYS.Gateway.Application/IYS.Gateway.Application.csproj src/IYS.Gateway.Application/
COPY src/IYS.Gateway.Infrastructure/IYS.Gateway.Infrastructure.csproj src/IYS.Gateway.Infrastructure/
COPY src/IYS.Gateway.Api/IYS.Gateway.Api.csproj src/IYS.Gateway.Api/

RUN dotnet restore src/IYS.Gateway.Api/IYS.Gateway.Api.csproj

# Tüm kaynak kodu kopyala ve publish
COPY src/ src/
RUN dotnet publish src/IYS.Gateway.Api/IYS.Gateway.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ─── Runtime Stage ───────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS runtime
WORKDIR /app

# Güvenlik: root olmayan kullanıcı
RUN groupadd -r appgroup && useradd -r -g appgroup -d /app appuser
USER appuser

COPY --from=build /app/publish .

# Health check
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
    CMD ["dotnet", "IYS.Gateway.Api.dll", "--urls", "http://localhost:8080"] || exit 1

# Port
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "IYS.Gateway.Api.dll"]
