using IYS.Gateway.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

namespace IYS.Gateway.Api.Swagger;

/// <summary>
/// Endpoint açıklamasına (description/remarks) otomatik enum referans tablosu ekler.
/// 1. Request body model'deki [IysEnum] attribute'lerini okur
/// 2. Route/Query parametrelerini adlarına göre bilinen enum'larla eşleştirir
/// Endpoint'in üst kısmına tablo olarak yazar — her zaman açık ve görünür.
/// </summary>
public class IysEnumDescriptionFilter : IOperationFilter
{
    /// <summary>
    /// Parametre adı → enum tipi eşleştirme tablosu.
    /// Route/Query parametreleri için bilinen enum sabitleri.
    /// </summary>
    private static readonly Dictionary<string, Type> KnownParamEnums = new(StringComparer.OrdinalIgnoreCase)
    {
        ["recipientType"] = typeof(Domain.Enums.RecipientType),
        ["type"] = typeof(ConsentType),
        ["source"] = typeof(ConsentSource),
        ["status"] = typeof(ConsentStatus),
    };

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var enumInfos = new List<(string FieldName, List<string> Values)>();

        foreach (var param in context.MethodInfo.GetParameters())
        {
            // ── 1. Primitif parametreler: Route/Query (string, int vb.) ──
            if (param.ParameterType == typeof(string) &&
                KnownParamEnums.TryGetValue(param.Name ?? "", out var enumType))
            {
                var values = GetConstValues(enumType);
                if (values.Count > 0)
                {
                    enumInfos.Add((param.Name!, values));
                    // NOT: Schema.Enum eklenmez — dropdown yerine text input + tablo gösterilir
                }
            }

            // ── 2. Complex parametreler: Body model (class) ──
            if (param.ParameterType.IsClass && param.ParameterType != typeof(string))
            {
                ScanModelProperties(param.ParameterType, enumInfos);
            }
        }

        if (enumInfos.Count == 0) return;

        // ── 3. Kompakt tablo oluştur ──
        var sb = new StringBuilder();
        sb.AppendLine("\n\n---\nKabul edilen değerler:\n");
        sb.AppendLine("| Alan | Değerler |");
        sb.AppendLine("|:-----|:---------|");

        foreach (var (fieldName, values) in enumInfos)
        {
            var valuesStr = string.Join(", ", values);
            sb.AppendLine($"| {fieldName} | {valuesStr} |");
        }

        operation.Description = (operation.Description ?? "") + sb.ToString();
    }

    /// <summary>
    /// Model sınıfının property'lerini tarayarak [IysEnum] attribute'ü olanları bulur.
    /// Nested model'leri de tarar (ör: AddBatchConsentRequest.Consents listesindeki AddSingleConsentRequest).
    /// </summary>
    private static void ScanModelProperties(Type modelType, List<(string FieldName, List<string> Values)> enumInfos, HashSet<Type>? visited = null)
    {
        visited ??= new HashSet<Type>();
        if (!visited.Add(modelType)) return;

        foreach (var prop in modelType.GetProperties())
        {
            var iysEnum = prop.GetCustomAttribute<IysEnumAttribute>();
            if (iysEnum != null)
            {
                var values = GetConstValues(iysEnum.EnumType);
                if (values.Count > 0)
                {
                    var camelName = char.ToLowerInvariant(prop.Name[0]) + prop.Name[1..];
                    // Duplikat ekleme (aynı alan adı zaten varsa atla)
                    if (!enumInfos.Any(e => e.FieldName == camelName))
                    {
                        enumInfos.Add((camelName, values));
                    }
                }
            }

            // Nested model taraması (List<T>, T gibi)
            var propType = prop.PropertyType;
            if (propType.IsGenericType)
            {
                propType = propType.GetGenericArguments().FirstOrDefault() ?? propType;
            }
            if (propType.IsClass && propType != typeof(string))
            {
                ScanModelProperties(propType, enumInfos, visited);
            }
        }
    }

    /// <summary>
    /// Static class'taki tüm public const string değerlerini döner.
    /// </summary>
    private static List<string> GetConstValues(Type type)
    {
        return type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
            .Select(f => f.GetRawConstantValue() as string)
            .Where(v => v != null)
            .Select(v => v!)
            .ToList();
    }
}
