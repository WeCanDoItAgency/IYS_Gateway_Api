namespace IYS.Gateway.Domain.Constants;

/// <summary>
/// IYS API endpoint URL sabitleri.
/// Tüm path parametreleri ({iysCode}, {brandCode} vb.) çağrı anında string.Format ile doldurulur.
/// </summary>
public static class IysEndpoints
{
    // ─── KİMLİK YÖNETİMİ ───────────────────────────────────────
    /// <summary>
    /// OAuth2 token alma/yenileme. IP başına saatte en fazla 10 istek.
    /// Rate Limit: 10 istek/saat/IP
    /// </summary>
    public const string Token = "/oauth2/token";

    // ─── İZİN YÖNETİMİ ─────────────────────────────────────────
    /// <summary>
    /// Tekil izin ekleme. POST ile izin kaydı oluşturur.
    /// Rate Limit: Dakikada 50 istek
    /// </summary>
    public const string AddSingleConsent = "/sps/{0}/brands/{1}/consents";

    /// <summary>
    /// Tekil izin ekleme (v2). Geliştirilmiş response formatı.
    /// Rate Limit: Dakikada 50 istek
    /// </summary>
    public const string AddSingleConsentV2 = "/v2/sps/{0}/brands/{1}/consents";

    /// <summary>
    /// Toplu izin ekleme isteği. Asenkron işlem başlatır, requestId döner.
    /// Rate Limit: Dakikada 2 istek, maksimum 10.000 kayıt/istek
    /// </summary>
    public const string AddBatchConsent = "/sps/{0}/brands/{1}/consents/request";

    /// <summary>
    /// Toplu izin ekleme isteği (v2). Geliştirilmiş response formatı.
    /// Rate Limit: Dakikada 2 istek, maksimum 10.000 kayıt/istek
    /// </summary>
    public const string AddBatchConsentV2 = "/v2/sps/{0}/brands/{1}/consents/request";

    /// <summary>
    /// Toplu izin ekleme sonuç sorgulama. requestId ile asenkron işlem durumunu sorgular.
    /// Rate Limit: Dakikada 20 istek
    /// </summary>
    public const string GetBatchConsentStatus = "/sps/{0}/brands/{1}/consents/request/{2}";

    /// <summary>
    /// Toplu izin ekleme sonuç sorgulama (v2).
    /// Rate Limit: Dakikada 20 istek
    /// </summary>
    public const string GetBatchConsentStatusV2 = "/v2/sps/{0}/brands/{1}/consents/request/{2}";

    /// <summary>
    /// Tekil izin durum sorgulama. Belirli bir alıcının izin durumunu sorgular.
    /// Rate Limit: Dakikada 100 istek
    /// </summary>
    public const string GetSingleConsentStatus = "/sps/{0}/brands/{1}/consents/status";

    /// <summary>
    /// Çoklu izin durum sorgulama. Birden fazla alıcının izin durumunu toplu sorgular.
    /// Rate Limit: Dakikada 10 istek, maksimum 1.000 alıcı/istek
    /// </summary>
    public const string GetMultipleConsentStatus = "/sps/{0}/brands/{1}/consents/{2}/status/{3}";

    /// <summary>
    /// İzin geçmişi sorgulama. Belirli bir alıcının izin değişiklik geçmişini döner.
    /// Rate Limit: Dakikada 100 istek
    /// </summary>
    public const string GetConsentHistory = "/sps/{0}/brands/{1}/consents/history";

    /// <summary>
    /// İzin değişiklikleri. Belirli bir tarihten sonraki izin hareketlerini döner.
    /// Rate Limit: Dakikada 50 istek, varsayılan limit 500
    /// </summary>
    public const string GetConsentChanges = "/sps/{0}/brands/{1}/consents/changes";

    // ─── PUSH BİLDİRİM ─────────────────────────────────────────
    /// <summary>
    /// Push bildirim kaydı oluşturma. İzin hareketlerinin anlık iletileceği URL kaydeder.
    /// Rate Limit: Dakikada 5 istek
    /// </summary>
    public const string PushRegistration = "/sps/{0}/brands/{1}/push/registration";

    /// <summary>
    /// Push bildirim kaydını silme.
    /// Rate Limit: Dakikada 5 istek
    /// </summary>
    public const string PushUnregistration = "/sps/{0}/brands/{1}/push/unregistration";

    // ─── MARKA YÖNETİMİ ────────────────────────────────────────
    /// <summary>
    /// Hizmet sağlayıcıya ait markaların listesi.
    /// Rate Limit: Dakikada 30 istek
    /// </summary>
    public const string GetBrands = "/sps/{0}/brands";

    /// <summary>
    /// Entegratöre bağlı hizmet sağlayıcıların listesi.
    /// Rate Limit: Dakikada 30 istek
    /// </summary>
    public const string GetIntegratorBrands = "/integrator/{0}/sps";

    /// <summary>
    /// Entegratöre bağlı belirli bir hizmet sağlayıcının detayı.
    /// Rate Limit: Dakikada 30 istek
    /// </summary>
    public const string GetIntegratorBrandDetail = "/integrator/{0}/sps/{1}";

    // ─── BAYİ YÖNETİMİ ─────────────────────────────────────────
    /// <summary>
    /// Bayi oluşturma/listeleme endpoint'i.
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string Retailers = "/sps/{0}/brands/{1}/retailers";

    /// <summary>
    /// Bayi detay/silme endpoint'i. {2} = retailerCode
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string RetailerDetail = "/sps/{0}/brands/{1}/retailers/{2}";

    // ─── BAYİ İZİN YÖNETİMİ ────────────────────────────────────
    /// <summary>
    /// Bayi izin erişimi ekleme/silme/listeleme. {2} = retailerCode
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string RetailerConsentAccess = "/sps/{0}/brands/{1}/retailers/{2}/consent-access";

    /// <summary>
    /// Bayi izin erişimi verme (grant). {2} = retailerCode
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string RetailerConsentAccessGrant = "/sps/{0}/brands/{1}/retailers/{2}/consent-access/grant";

    /// <summary>
    /// Bayi tüm izin erişimlerini silme. {2} = retailerCode
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string RetailerConsentAccessAll = "/sps/{0}/brands/{1}/retailers/{2}/consent-access-all";

    // ─── MUTABAKAT YÖNETİMİ ────────────────────────────────────
    /// <summary>
    /// Mutabakat anlaşması kaydetme/listeleme.
    /// Rate Limit: Dakikada 5 istek
    /// </summary>
    public const string ReconciliationAgreements = "/sps/{0}/brands/{1}/reconciliation/agreements";

    /// <summary>
    /// Mutabakat zaman damgası.
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string ReconciliationTimestamp = "/sps/{0}/brands/{1}/reconciliation/timestamp";

    /// <summary>
    /// İzin değişiklik özeti.
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string ChangeSummary = "/sps/{0}/brands/{1}/consents/changes/summary";

    /// <summary>
    /// Günlük değişiklik dosyası. Belirli bir tarihe ait izin değişikliklerini dosya olarak indirir.
    /// Rate Limit: Dakikada 5 istek
    /// </summary>
    public const string DailyChangeFile = "/sps/{0}/brands/{1}/consents/changes/daily-file";

    // ─── ABONELİK YÖNETİMİ ─────────────────────────────────────
    /// <summary>
    /// Hizmet sağlayıcı abonelik bilgileri.
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string SpSubscription = "/sps/{0}/subscription";

    /// <summary>
    /// Entegratör abonelik bilgileri.
    /// Rate Limit: Dakikada 10 istek
    /// </summary>
    public const string IntegratorSubscription = "/integrator/{0}/subscription";

    // ─── INFO SERVİSLERİ ────────────────────────────────────────
    /// <summary>İl listesi</summary>
    public const string Cities = "/consents/cities";

    /// <summary>İl detayı. {0} = cityCode</summary>
    public const string CityDetail = "/consents/cities/{0}";

    /// <summary>İlçe listesi. {0} = cityCode</summary>
    public const string Towns = "/consents/cities/{0}/towns";

    /// <summary>İlçe detayı. {0} = cityCode, {1} = townCode</summary>
    public const string TownDetail = "/consents/cities/{0}/towns/{1}";

    // ─── İLETİ ViA ──────────────────────────────────────────────
    /// <summary>ViA izin süreci başlatma</summary>
    public const string ViaConsent = "/via/sps/{0}/consent";

    /// <summary>ViA onaylama</summary>
    public const string ViaConfirmation = "/via/sps/{0}/confirmation";

    /// <summary>ViA red linkleri oluşturma</summary>
    public const string ViaHashLinks = "/sps/{0}/brands/{1}/via-hash-links";

    /// <summary>ViA izin isteği durumu sorgulama. {1} = requestId</summary>
    public const string ViaRequestStatus = "/via/sps/{0}/consent/request/{1}";

    /// <summary>ViA izin dosyası indirme. {1} = requestId</summary>
    public const string ViaFile = "/via/sps/{0}/consent/{1}";

    /// <summary>KVK izin durumu sorgulama</summary>
    public const string ViaKvkStatus = "/via/sps/{0}/consent/status";

    /// <summary>ViA aydınlatma dosyası indirme. {1} = requestId</summary>
    public const string ViaClarificationFile = "/via/sps/{0}/via/clarification/{1}/file";

    // ─── ViA PASS ───────────────────────────────────────────────
    /// <summary>SMS OTP başlatma</summary>
    public const string ViaPassSmsStart = "/otp-management/api/v1/{0}/sms/start";

    /// <summary>SMS OTP tamamlama</summary>
    public const string ViaPassSmsComplete = "/otp-management/api/v1/sms/complete";

    /// <summary>E-posta OTP başlatma</summary>
    public const string ViaPassEmailStart = "/otp-management/api/v1/{0}/email/start";

    /// <summary>E-posta OTP tamamlama</summary>
    public const string ViaPassEmailComplete = "/otp-management/api/v1/email/complete";

    /// <summary>SMS kısa URL başlatma</summary>
    public const string ViaPassSmsShortUrl = "/otp-management/api/v1/{0}/sms/start/short-url";

    /// <summary>E-posta kısa URL başlatma</summary>
    public const string ViaPassEmailShortUrl = "/otp-management/api/v1/{0}/email/start/short-url";

    /// <summary>Aydınlatma dosyası indirme. {0} = iysCode, {1} = requestId</summary>
    public const string ViaPassClarificationFile = "/otp-management/api/v1/get-clarification-file/{0}/{1}";

    /// <summary>İşlem geçmişi sorgulama</summary>
    public const string ViaPassRequestHistory = "/otp-management/api/v1/request-history";

    /// <summary>ViA PASS abonelik bilgileri</summary>
    public const string ViaPassSubscription = "/otp-management/api/v1/subscription/{0}";

    // ─── ViA FRAME ──────────────────────────────────────────────
    /// <summary>Widget loader yükleme. {0} = widgetUUID</summary>
    public const string WidgetLoader = "/widget/load-widgetloader/{0}";

    /// <summary>Widget public key. {0} = widgetUUID</summary>
    public const string WidgetPublicKey = "/widget/publicKey/{0}";

    /// <summary>Widget yükleme. {0} = widgetUUID</summary>
    public const string WidgetLoad = "/widget/load-widget/{0}";

    /// <summary>Widget süreci başlatma. {0} = widgetUUID</summary>
    public const string WidgetProcessStart = "/widget/process/start/{0}";

    /// <summary>Widget süreci tamamlama. {0} = widgetUUID</summary>
    public const string WidgetProcessComplete = "/widget/process/complete/{0}";

    // ─── HANDLER ALIAS'LARI ────────────────────────────────────
    // Not: Aşağıdakiler yukarıdaki sabitlerin handler'larda kullanılan isimleridir

    /// <summary>Marka detayı. {0} = iysCode, {1} = brandCode</summary>
    public const string GetBrandDetail = "/sps/{0}/brands/{1}";

    /// <summary>Bayi listesi. {0} = iysCode, {1} = brandCode</summary>
    public const string GetRetailers = "/sps/{0}/brands/{1}/retailers";

    /// <summary>Bayi detayı. {0} = iysCode, {1} = brandCode, {2} = retailerCode</summary>
    public const string GetRetailerDetail = "/sps/{0}/brands/{1}/retailers/{2}";

    /// <summary>İzin sayısı mutabakat raporu. {0} = iysCode, {1} = brandCode</summary>
    public const string GetConsentCount = "/sps/{0}/brands/{1}/consents/count";

    /// <summary>IYS iletişim kaynakları listesi.</summary>
    public const string GetSources = "/sps/sources";

    /// <summary>ViA abonelik listesi. {0} = iysCode, {1} = brandCode</summary>
    public const string GetViaSubscriptions = "/sps/{0}/brands/{1}/via/subscriptions";

    /// <summary>ViA abonelik detayı. {0} = iysCode, {1} = brandCode, {2} = subscriptionCode</summary>
    public const string GetViaSubscriptionDetail = "/sps/{0}/brands/{1}/via/subscriptions/{2}";

    /// <summary>KVK izin durumu sorgulama. {0} = iysCode, {1} = brandCode</summary>
    public const string GetKvkConsentStatus = "/sps/{0}/brands/{1}/kvk/consents/status";

    /// <summary>KVK izin ekleme. {0} = iysCode, {1} = brandCode</summary>
    public const string AddKvkConsent = "/sps/{0}/brands/{1}/kvk/consents";

    /// <summary>ViaPass doğrulama. {0} = iysCode, {1} = brandCode</summary>
    public const string ViaPassVerify = "/sps/{0}/brands/{1}/viapass/verify";

    /// <summary>ViaPass gönderme. {0} = iysCode, {1} = brandCode</summary>
    public const string ViaPassSend = "/sps/{0}/brands/{1}/viapass/send";

    /// <summary>ViaFrame URL üretme. {0} = iysCode, {1} = brandCode</summary>
    public const string ViaFrameUrl = "/sps/{0}/brands/{1}/viaframe/url";

    /// <summary>ViaFrame sonuç sorgulama. {0} = iysCode, {1} = brandCode, {2} = token</summary>
    public const string ViaFrameResult = "/sps/{0}/brands/{1}/viaframe/result/{2}";
}

