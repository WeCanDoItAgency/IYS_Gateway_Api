using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using IYS.Gateway.Api.Middleware;
using IYS.Gateway.Infrastructure;
using IYS.Gateway.Infrastructure.Mongo.Settings;

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

// ─── Infrastructure DI (HttpClient + Polly + Token Manager + Firm Resolver) ──
builder.Services.AddInfrastructure(iysBaseUrl);

// ─── HttpContext Accessor (Servis handler'larında FirmGuid erişimi için) ──
builder.Services.AddHttpContextAccessor();

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

// ─── Health Check ───────────────────────────────────────────────
builder.Services.AddHealthChecks();

var app = builder.Build();

// ─── Middleware Pipeline ────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IYS Gateway API v1"));
}

// Global hata yakalama — tüm exception'ları JSON yanıta dönüştürür
app.UseGlobalExceptionHandler();

// FirmGuid zorunluluk kontrolü
app.UseFirmGuidValidation();

app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
