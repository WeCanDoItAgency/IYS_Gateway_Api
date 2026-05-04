using IYS.Gateway.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace IYS.Gateway.Api.Swagger;

/// <summary>
/// Swagger UI'da IYS API enum değerlerini otomatik görünür yapar.
/// [IysEnum(typeof(ConsentType))] attribute'ünü okur, ilgili static class'taki
/// tüm public const string alanlarını:
/// 1. Schema enum olarak ekler (Schema sekmesinde dropdown)
/// 2. Description'a "Kabul edilen değerler: X, Y, Z" olarak ekler (hemen görünür)
/// </summary>
public class IysEnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null || context.Type == null)
            return;

        foreach (var property in context.Type.GetProperties())
        {
            var iysEnum = property.GetCustomAttribute<IysEnumAttribute>();
            if (iysEnum == null) continue;

            // Property adını camelCase'e çevir (Swagger convention)
            var propName = char.ToLowerInvariant(property.Name[0]) + property.Name[1..];

            if (!schema.Properties.TryGetValue(propName, out var propSchema))
                continue;

            // Static class'taki tüm public const string alanlarını oku
            var values = iysEnum.EnumType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
                .Select(f => f.GetRawConstantValue() as string)
                .Where(v => v != null)
                .OrderBy(v => v)
                .ToList();

            if (values.Count == 0) continue;

            // 1. Schema enum olarak ekle (Schema sekmesinde görünür)
            propSchema.Enum = values
                .Select(v => (IOpenApiAny)new OpenApiString(v!))
                .ToList();

            // 2. Description'a kabul edilen değerleri ekle (Example Value görünümünde hemen okunur)
            var valuesText = string.Join(" | ", values);
            var suffix = $"\n\n**Kabul edilen değerler:** `{valuesText}`";

            propSchema.Description = string.IsNullOrEmpty(propSchema.Description)
                ? suffix.TrimStart()
                : propSchema.Description + suffix;
        }
    }
}
