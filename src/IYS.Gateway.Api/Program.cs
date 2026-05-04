using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using IYS.Gateway.Api.Middleware;
using System.Text.Json;
using IYS.Gateway.Infrastructure;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// ─── Azure Key Vault ────────────────────────────────────────────
var builtConfig = builder.Configuration;
string kvUrl = builtConfig["KeyVaultConfig:Url"]!;
string tenantId = builtConfig["KeyVaultConfig:TenantId"]!;
string clientId = builtConfig["KeyVaultConfig:ClientId"]!;
string clientSecret = builtConfig["KeyVaultConfig:ClientSecretId"]!;

var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
var client = new SecretClient(new Uri(kvUrl), credential);
builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

// ─── GlobalAppSettings Singleton Konfigürasyonu ─────────────────
GlobalAppSettings.Instance.SetConfiguration(builder.Configuration);

// ─── IYS API Base URL ───────────────────────────────────────────
var useProduction = builder.Configuration.GetValue<bool>("IysApi:UseProduction");
var iysBaseUrl = useProduction
    ? builder.Configuration["IysApi:ProductionBaseUrl"]!
    : builder.Configuration["IysApi:BaseUrl"]!;

// ─── Infrastructure DI (HttpClient + Polly + Token Manager + Firm Resolver + Consent Tracking) ──
builder.Services.AddInfrastructure(iysBaseUrl, builder.Configuration);

// ─── HttpContext Accessor (Servis handler'larında FirmGuid erişimi için) ──
builder.Services.AddHttpContextAccessor();

// ─── [IMPROVEMENT #5] Response Compression — gzip/brotli ────────
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/json" });
});

// ─── Controllers + Swagger ──────────────────────────────────────
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "IYS Gateway API",
        Version = "v1",
        Description = "İleti Yönetim Sistemi (IYS) Gateway API — Tüm IYS servislerinin merkezi proxy'si. Her istek X-Firm-Guid header'ı gerektirir."
    });

    // Tüm endpoint'lere X-Firm-Guid header alanı ekle
    c.OperationFilter<IYS.Gateway.Api.Swagger.FirmGuidHeaderFilter>();

    // IYS enum değerlerini Swagger UI'da görünür yap ([IysEnum] → Schema enum + description)
    c.SchemaFilter<IYS.Gateway.Api.Swagger.IysEnumSchemaFilter>();

    // XML dokümantasyonu dahil et (ÖNCELİKLİ — description'ları XML'den yükler)
    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
    foreach (var xmlFile in xmlFiles)
    {
        c.IncludeXmlComments(xmlFile);
    }

    // Endpoint açıklamasına otomatik enum referans tablosu ekle (XML'den SONRA — ezilmez)
    c.OperationFilter<IYS.Gateway.Api.Swagger.IysEnumDescriptionFilter>();
});

var app = builder.Build();

// ─── Middleware Pipeline (sıra önemli!) ─────────────────────────

// [IMPROVEMENT #5] Response Compression — en erken çalışmalı
app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IYS Gateway API v1"));
}

// [IMPROVEMENT #4] Correlation ID — tüm middleware'lerden önce log scope aç
app.UseCorrelationId();

// Global hata yakalama — tüm exception'ları JSON yanıta dönüştürür
app.UseGlobalExceptionHandler();

// FirmGuid zorunluluk kontrolü
app.UseFirmGuidValidation();

app.UseAuthorization();
app.MapControllers();

// [IMPROVEMENT #8] Health Check — detaylı JSON response
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var result = new
        {
            status = report.Status.ToString(),
            duration = report.TotalDuration.TotalMilliseconds + "ms",
            checks = report.Entries.Select(e => new
            {
                name = e.Key,
                status = e.Value.Status.ToString(),
                description = e.Value.Description,
                data = e.Value.Data
            })
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(result,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true }));
    }
});

app.Run();
