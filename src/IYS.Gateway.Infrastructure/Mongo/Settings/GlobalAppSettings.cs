using Microsoft.Extensions.Configuration;

namespace IYS.Gateway.Infrastructure.Mongo.Settings;

/// <summary>
/// Uygulama genelinde konfigürasyon erişimi sağlayan Singleton sınıf.
/// PORTAL_JOB_ORCHESTRATOR ile birebir aynı implementasyon.
/// Azure Key Vault entegrasyonu sonrası tüm secret'lar bu sınıf üzerinden okunur.
/// </summary>
public class GlobalAppSettings
{
    private static GlobalAppSettings _instance;
    private static readonly object ObjLocked = new object();
    private IConfiguration _configuration;

    protected GlobalAppSettings()
    {
    }

    public void SetConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static GlobalAppSettings Instance
    {
        get
        {
            if (null == _instance)
            {
                lock (ObjLocked)
                {
                    if (null == _instance)
                        _instance = new GlobalAppSettings();
                }
            }
            return _instance;
        }
    }

    public string GetConnection(string key, string defaultValue = "")
    {
        try
        {
            return _configuration.GetConnectionString(key);
        }
        catch
        {
            return defaultValue;
        }
    }

    public T Get<T>(string key = null)
    {
        if (string.IsNullOrWhiteSpace(key))
            return _configuration.Get<T>();
        else
            return _configuration.GetSection(key).Get<T>();
    }

    public T Get<T>(string key, T defaultValue)
    {
        if (_configuration.GetSection(key) == null)
            return defaultValue;

        if (string.IsNullOrWhiteSpace(key))
            return _configuration.Get<T>();
        else
            return _configuration.GetSection(key).Get<T>();
    }

    public static T GetObject<T>(string key = null)
    {
        if (string.IsNullOrWhiteSpace(key))
            return Instance._configuration.Get<T>();
        else
        {
            var section = Instance._configuration.GetSection(key);
            return section.Get<T>();
        }
    }

    public static T GetObject<T>(string key, T defaultValue)
    {
        if (Instance._configuration.GetSection(key) == null)
            return defaultValue;

        if (string.IsNullOrWhiteSpace(key))
            return Instance._configuration.Get<T>();
        else
            return Instance._configuration.GetSection(key).Get<T>();
    }
}
