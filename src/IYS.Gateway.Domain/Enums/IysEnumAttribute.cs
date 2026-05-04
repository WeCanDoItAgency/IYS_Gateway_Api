using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// IYS enum sabit sınıfını işaretler ve runtime'da doğrulama yapar.
/// SchemaFilter bu attribute'ü okuyarak Swagger UI'da kabul edilen değerleri otomatik olarak listeler.
/// Aynı zamanda ValidationAttribute olarak çalışır — geçersiz enum değerleri IYS API'ye gönderilmeden yakalanır.
/// Yeni bir const eklediğinizde Swagger + doğrulama otomatik güncellenir — başka bir yere dokunmaya gerek yok.
/// 
/// Kullanım: [IysEnum(typeof(ConsentType))]
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class IysEnumAttribute : ValidationAttribute
{
    /// <summary>Sabit değerleri içeren static class tipi</summary>
    public Type EnumType { get; }

    private readonly HashSet<string> _validValues;

    public IysEnumAttribute(Type enumType)
    {
        EnumType = enumType;

        // Sabit sınıfındaki tüm public const string alanlarını oku
        _validValues = enumType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
            .Select(f => (string)f.GetRawConstantValue()!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Runtime validation — geçersiz enum değeri IYS'ye gönderilmeden yakalanır.
    /// </summary>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success; // [Required] ile kontrol edilir

        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue))
            return ValidationResult.Success; // [Required] ile kontrol edilir

        if (!_validValues.Contains(stringValue))
        {
            var allowed = string.Join(", ", _validValues.Order());
            return new ValidationResult(
                $"'{stringValue}' geçersiz bir {EnumType.Name} değeridir. Kabul edilen değerler: {allowed}",
                new[] { validationContext.MemberName! });
        }

        return ValidationResult.Success;
    }
}
