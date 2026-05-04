namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// IYS enum sabit sınıfını işaretler. SchemaFilter bu attribute'ü okuyarak
/// Swagger UI'da kabul edilen değerleri otomatik olarak listeler.
/// Yeni bir const eklediğinizde Swagger otomatik güncellenir — başka bir yere dokunmaya gerek yok.
/// 
/// Kullanım: [IysEnum(typeof(ConsentType))]
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class IysEnumAttribute : Attribute
{
    /// <summary>Sabit değerleri içeren static class tipi</summary>
    public Type EnumType { get; }

    public IysEnumAttribute(Type enumType)
    {
        EnumType = enumType;
    }
}
