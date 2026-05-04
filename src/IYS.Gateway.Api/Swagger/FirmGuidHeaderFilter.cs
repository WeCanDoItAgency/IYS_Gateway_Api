using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IYS.Gateway.Api.Swagger;

/// <summary>
/// Tüm endpoint'lere X-Firm-Guid header parametresini otomatik ekler.
/// Swagger UI'da her istek için header giriş alanı oluşturur.
/// </summary>
public class FirmGuidHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Firm-Guid",
            In = ParameterLocation.Header,
            Required = true,
            Description = "Firma tanımlayıcı GUID. Tüm işlemler bu firma bağlamında çalışır. Örnek: 3fa85f64-5717-4562-b3fc-2c963f66afa6",
            Schema = new OpenApiSchema
            {
                Type = "string",
                Format = "uuid"
            }
        });
    }
}
