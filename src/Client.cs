using System.Net.Http.Json;
using System.Text.Json;

namespace uapi;

public class RateLimitPolicyEntry {
    public string Name { get; init; } = "";
    public long? Quota { get; init; }
    public string? Unit { get; init; }
    public int? WindowSeconds { get; init; }
}

public class RateLimitStateEntry {
    public string Name { get; init; } = "";
    public long? Remaining { get; init; }
    public string? Unit { get; init; }
    public int? ResetAfterSeconds { get; init; }
}

public class ResponseMeta {
    public string? RequestId { get; set; }
    public int? RetryAfterSeconds { get; set; }
    public string? DebitStatus { get; set; }
    public long? CreditsRequested { get; set; }
    public long? CreditsCharged { get; set; }
    public string? CreditsPricing { get; set; }
    public int? ActiveQuotaBuckets { get; set; }
    public bool? StopOnEmpty { get; set; }
    public string? RateLimitPolicyRaw { get; set; }
    public string? RateLimitRaw { get; set; }
    public Dictionary<string, RateLimitPolicyEntry> RateLimitPolicies { get; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, RateLimitStateEntry> RateLimits { get; } = new(StringComparer.OrdinalIgnoreCase);
    public long? BalanceLimitCents { get; set; }
    public long? BalanceRemainingCents { get; set; }
    public long? QuotaLimitCredits { get; set; }
    public long? QuotaRemainingCredits { get; set; }
    public long? VisitorQuotaLimitCredits { get; set; }
    public long? VisitorQuotaRemainingCredits { get; set; }
    public Dictionary<string, string> RawHeaders { get; } = new(StringComparer.OrdinalIgnoreCase);
}

public class UapiError: Exception {
    public string Code { get; }
    public int Status { get; }
    public JsonElement? Details { get; }
    public JsonElement? Payload { get; }
    public ResponseMeta? Meta { get; }
    public UapiError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base($"[{status}] {code}: {message}") { Code = code; Status = status; Details = details; Payload = payload; Meta = meta; }
}

public class ApiErrorError: UapiError { public ApiErrorError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class AvatarNotFoundError: UapiError { public AvatarNotFoundError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class ConversionFailedError: UapiError { public ConversionFailedError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class FileOpenErrorError: UapiError { public FileOpenErrorError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class FileRequiredError: UapiError { public FileRequiredError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class InsufficientCreditsError: UapiError { public InsufficientCreditsError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class InternalServerErrorError: UapiError { public InternalServerErrorError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class InvalidParameterError: UapiError { public InvalidParameterError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class InvalidParamsError: UapiError { public InvalidParamsError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class NotFoundError: UapiError { public NotFoundError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class NoMatchError: UapiError { public NoMatchError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class NoTrackingDataError: UapiError { public NoTrackingDataError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class PhoneInfoFailedError: UapiError { public PhoneInfoFailedError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class RecognitionFailedError: UapiError { public RecognitionFailedError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class RequestEntityTooLargeError: UapiError { public RequestEntityTooLargeError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class ServiceBusyError: UapiError { public ServiceBusyError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class TimezoneNotFoundError: UapiError { public TimezoneNotFoundError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class UnauthorizedError: UapiError { public UnauthorizedError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class UnsupportedCarrierError: UapiError { public UnsupportedCarrierError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class UnsupportedFormatError: UapiError { public UnsupportedFormatError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }
public class VisitorMonthlyQuotaExhaustedError: UapiError { public VisitorMonthlyQuotaExhaustedError(string code, int status, string message, JsonElement? details = null, JsonElement? payload = null, ResponseMeta? meta = null) : base(code,status,message,details,payload,meta) {} }


public class Client {
    private readonly HttpClient _http;
    public ResponseMeta? LastResponseMeta { get; private set; }
    public Client(string baseUrl, string? token = null) {
        var normalized = NormalizeBaseUrl(baseUrl);
        _http = new HttpClient { BaseAddress = new Uri(normalized) };
        if (!string.IsNullOrEmpty(token)) _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }
    private static string NormalizeBaseUrl(string baseUrl) {
        var normalized = baseUrl.TrimEnd('/');
        if (normalized.EndsWith("/api/v1", StringComparison.OrdinalIgnoreCase)) {
            normalized = normalized[..^"/api/v1".Length];
        }
        return normalized.EndsWith("/") ? normalized : normalized + "/";
    }
    private async Task<object?> RequestAsync(string method, string path, Dictionary<string, object?>? query = null, object? body = null) {
        var relative = path.TrimStart('/');
        var qs = query is null || query.Count == 0
            ? ""
            : "?" + string.Join("&", query.Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value?.ToString() ?? "")}"));
        var uri = relative + qs;
        var msg = new HttpRequestMessage(new HttpMethod(method), uri);
        if (body is not null) msg.Content = JsonContent.Create(body);
        var res = await _http.SendAsync(msg);
        LastResponseMeta = ExtractMeta(res);
        if (!res.IsSuccessStatusCode) {
            var text = await res.Content.ReadAsStringAsync();
            var payload = ParseJson(text);
            var code = (ReadString(payload, "code") ?? ReadString(payload, "error") ?? DefaultCode((int)res.StatusCode)).ToUpperInvariant();
            var message = ReadString(payload, "message") ?? (!string.IsNullOrWhiteSpace(text) ? text : res.ReasonPhrase ?? "");
            throw From(code, (int)res.StatusCode, message, PickDetails(payload), payload, LastResponseMeta);
        }
        var ct = res.Content.Headers.ContentType?.MediaType ?? "";
        if (ct.Contains("json")) return await res.Content.ReadFromJsonAsync<object>();
        return await res.Content.ReadAsStringAsync();
    }
    private static string DefaultCode(int status) => status switch {
        400 => "INVALID_PARAMETER", 401 => "UNAUTHORIZED", 402 => "INSUFFICIENT_CREDITS", 404 => "NOT_FOUND", 429 => "SERVICE_BUSY", 500 => "INTERNAL_SERVER_ERROR", _ => "API_ERROR",
    };
    private static UapiError From(string code, int status, string message, JsonElement? details, JsonElement? payload, ResponseMeta? meta) => code switch {
        "API_ERROR" => new ApiErrorError(code, status, message, details, payload, meta),
        "AVATAR_NOT_FOUND" => new AvatarNotFoundError(code, status, message, details, payload, meta),
        "CONVERSION_FAILED" => new ConversionFailedError(code, status, message, details, payload, meta),
        "FILE_OPEN_ERROR" => new FileOpenErrorError(code, status, message, details, payload, meta),
        "FILE_REQUIRED" => new FileRequiredError(code, status, message, details, payload, meta),
        "INSUFFICIENT_CREDITS" => new InsufficientCreditsError(code, status, message, details, payload, meta),
        "INTERNAL_SERVER_ERROR" => new InternalServerErrorError(code, status, message, details, payload, meta),
        "INVALID_PARAMETER" => new InvalidParameterError(code, status, message, details, payload, meta),
        "INVALID_PARAMS" => new InvalidParamsError(code, status, message, details, payload, meta),
        "NOT_FOUND" => new NotFoundError(code, status, message, details, payload, meta),
        "NO_MATCH" => new NoMatchError(code, status, message, details, payload, meta),
        "NO_TRACKING_DATA" => new NoTrackingDataError(code, status, message, details, payload, meta),
        "PHONE_INFO_FAILED" => new PhoneInfoFailedError(code, status, message, details, payload, meta),
        "RECOGNITION_FAILED" => new RecognitionFailedError(code, status, message, details, payload, meta),
        "REQUEST_ENTITY_TOO_LARGE" => new RequestEntityTooLargeError(code, status, message, details, payload, meta),
        "SERVICE_BUSY" => new ServiceBusyError(code, status, message, details, payload, meta),
        "TIMEZONE_NOT_FOUND" => new TimezoneNotFoundError(code, status, message, details, payload, meta),
        "UNAUTHORIZED" => new UnauthorizedError(code, status, message, details, payload, meta),
        "UNSUPPORTED_CARRIER" => new UnsupportedCarrierError(code, status, message, details, payload, meta),
        "UNSUPPORTED_FORMAT" => new UnsupportedFormatError(code, status, message, details, payload, meta),
        "VISITOR_MONTHLY_QUOTA_EXHAUSTED" => new VisitorMonthlyQuotaExhaustedError(code, status, message, details, payload, meta),
        _ => new UapiError(code,status,message,details,payload,meta)
    };

    private static JsonElement? ParseJson(string text) {
        if (string.IsNullOrWhiteSpace(text)) {
            return null;
        }
        try {
            return JsonDocument.Parse(text).RootElement.Clone();
        } catch {
            return null;
        }
    }

    private static string? ReadString(JsonElement? payload, string key) {
        if (payload is not JsonElement element || element.ValueKind != JsonValueKind.Object) {
            return null;
        }
        return element.TryGetProperty(key, out var value) && value.ValueKind != JsonValueKind.Null ? value.ToString() : null;
    }

    private static JsonElement? PickDetails(JsonElement? payload) {
        if (payload is not JsonElement element || element.ValueKind != JsonValueKind.Object) {
            return null;
        }
        foreach (var key in new[] { "details", "quota", "docs" }) {
            if (element.TryGetProperty(key, out var value)) {
                return value.Clone();
            }
        }
        return null;
    }

    private static ResponseMeta ExtractMeta(HttpResponseMessage response) {
        var meta = new ResponseMeta();
        foreach (var header in response.Headers) {
            meta.RawHeaders[header.Key] = string.Join(", ", header.Value);
        }
        foreach (var header in response.Content.Headers) {
            meta.RawHeaders[header.Key] = string.Join(", ", header.Value);
        }

        meta.RequestId = GetHeader(meta.RawHeaders, "X-Request-ID");
        meta.RetryAfterSeconds = ParseInt(GetHeader(meta.RawHeaders, "Retry-After"));
        meta.DebitStatus = GetHeader(meta.RawHeaders, "UAPI-Debit-Status");
        meta.CreditsRequested = ParseLong(GetHeader(meta.RawHeaders, "UAPI-Credits-Requested"));
        meta.CreditsCharged = ParseLong(GetHeader(meta.RawHeaders, "UAPI-Credits-Charged"));
        meta.CreditsPricing = GetHeader(meta.RawHeaders, "UAPI-Credits-Pricing");
        meta.ActiveQuotaBuckets = ParseInt(GetHeader(meta.RawHeaders, "UAPI-Quota-Active-Buckets"));
        meta.StopOnEmpty = ParseBool(GetHeader(meta.RawHeaders, "UAPI-Stop-On-Empty"));
        meta.RateLimitPolicyRaw = GetHeader(meta.RawHeaders, "RateLimit-Policy");
        meta.RateLimitRaw = GetHeader(meta.RawHeaders, "RateLimit");

        foreach (var item in ParseStructuredItems(meta.RateLimitPolicyRaw)) {
            meta.RateLimitPolicies[item.Name] = new RateLimitPolicyEntry {
                Name = item.Name,
                Quota = ParseLong(item.Params.GetValueOrDefault("q")),
                Unit = item.Params.GetValueOrDefault("uapi-unit"),
                WindowSeconds = ParseInt(item.Params.GetValueOrDefault("w")),
            };
        }
        foreach (var item in ParseStructuredItems(meta.RateLimitRaw)) {
            meta.RateLimits[item.Name] = new RateLimitStateEntry {
                Name = item.Name,
                Remaining = ParseLong(item.Params.GetValueOrDefault("r")),
                Unit = item.Params.GetValueOrDefault("uapi-unit"),
                ResetAfterSeconds = ParseInt(item.Params.GetValueOrDefault("t")),
            };
        }

        meta.BalanceLimitCents = meta.RateLimitPolicies.TryGetValue("billing-balance", out var balancePolicy) ? balancePolicy.Quota : null;
        meta.BalanceRemainingCents = meta.RateLimits.TryGetValue("billing-balance", out var balanceState) ? balanceState.Remaining : null;
        meta.QuotaLimitCredits = meta.RateLimitPolicies.TryGetValue("billing-quota", out var quotaPolicy) ? quotaPolicy.Quota : null;
        meta.QuotaRemainingCredits = meta.RateLimits.TryGetValue("billing-quota", out var quotaState) ? quotaState.Remaining : null;
        meta.VisitorQuotaLimitCredits = meta.RateLimitPolicies.TryGetValue("visitor-quota", out var visitorQuotaPolicy) ? visitorQuotaPolicy.Quota : null;
        meta.VisitorQuotaRemainingCredits = meta.RateLimits.TryGetValue("visitor-quota", out var visitorQuotaState) ? visitorQuotaState.Remaining : null;
        return meta;
    }

    private sealed class StructuredItem {
        public string Name { get; init; } = "";
        public Dictionary<string, string> Params { get; } = new(StringComparer.OrdinalIgnoreCase);
    }

    private static IEnumerable<StructuredItem> ParseStructuredItems(string? raw) {
        if (string.IsNullOrWhiteSpace(raw)) {
            yield break;
        }
        foreach (var chunk in raw.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) {
            var parts = chunk.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length == 0) {
                continue;
            }
            var item = new StructuredItem { Name = Unquote(parts[0]) };
            foreach (var part in parts.Skip(1)) {
                var eq = part.IndexOf('=');
                if (eq <= 0) {
                    continue;
                }
                item.Params[part[..eq].Trim()] = Unquote(part[(eq + 1)..]);
            }
            yield return item;
        }
    }

    private static string Unquote(string value) {
        var text = value.Trim();
        return text.Length >= 2 && text.StartsWith('"') && text.EndsWith('"') ? text[1..^1] : text;
    }

    private static string? GetHeader(Dictionary<string, string> headers, string key) => headers.TryGetValue(key, out var value) ? value : null;

    private static int? ParseInt(string? value) => int.TryParse(value, out var parsed) ? parsed : null;
    private static long? ParseLong(string? value) => long.TryParse(value, out var parsed) ? parsed : null;
    private static bool? ParseBool(string? value) => value?.Trim().ToLowerInvariant() switch {
        "true" => true,
        "false" => false,
        _ => null,
    };
    public ClipzyZaiXianJianTieBanApi ClipzyZaiXianJianTieBan => new ClipzyZaiXianJianTieBanApi(this);
    public class ClipzyZaiXianJianTieBanApi {
        private readonly Client _c; public ClipzyZaiXianJianTieBanApi(Client c) { _c = c; }
        public Task<object?> getClipzyGetAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/api/get";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("id")) query["id"] = args["id"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getClipzyRawAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/api/raw/{id}";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("id") && args["id"] != null) path = path.Replace("{"+ "id" +"}", args["id"]!.ToString());
            if (args != null && args.ContainsKey("key")) query["key"] = args["key"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postClipzyStoreAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/api/store";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("compressedData")) body["compressedData"] = args["compressedData"];
            if (args != null && args.ContainsKey("ttl")) body["ttl"] = args["ttl"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public ConvertApi Convert => new ConvertApi(this);
    public class ConvertApi {
        private readonly Client _c; public ConvertApi(Client c) { _c = c; }
        public Task<object?> getConvertUnixtimeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/convert/unixtime";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("time")) query["time"] = args["time"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postConvertJsonAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/convert/json";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("content")) body["content"] = args["content"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public DailyApi Daily => new DailyApi(this);
    public class DailyApi {
        private readonly Client _c; public DailyApi(Client c) { _c = c; }
        public Task<object?> getDailyNewsImageAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/daily/news-image";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public GameApi Game => new GameApi(this);
    public class GameApi {
        private readonly Client _c; public GameApi(Client c) { _c = c; }
        public Task<object?> getGameEpicFreeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/game/epic-free";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getGameMinecraftHistoryidAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/game/minecraft/historyid";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("name")) query["name"] = args["name"];
            if (args != null && args.ContainsKey("uuid")) query["uuid"] = args["uuid"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getGameMinecraftServerstatusAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/game/minecraft/serverstatus";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("server")) query["server"] = args["server"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getGameMinecraftUserinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/game/minecraft/userinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("username")) query["username"] = args["username"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getGameSteamSummaryAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/game/steam/summary";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("steamid")) query["steamid"] = args["steamid"];
            if (args != null && args.ContainsKey("id")) query["id"] = args["id"];
            if (args != null && args.ContainsKey("id3")) query["id3"] = args["id3"];
            if (args != null && args.ContainsKey("key")) query["key"] = args["key"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public ImageApi Image => new ImageApi(this);
    public class ImageApi {
        private readonly Client _c; public ImageApi(Client c) { _c = c; }
        public Task<object?> getAvatarGravatarAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/avatar/gravatar";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("email")) query["email"] = args["email"];
            if (args != null && args.ContainsKey("hash")) query["hash"] = args["hash"];
            if (args != null && args.ContainsKey("s")) query["s"] = args["s"];
            if (args != null && args.ContainsKey("d")) query["d"] = args["d"];
            if (args != null && args.ContainsKey("r")) query["r"] = args["r"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getImageBingDailyAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/bing-daily";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getImageMotouAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/motou";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("qq")) query["qq"] = args["qq"];
            if (args != null && args.ContainsKey("bg_color")) query["bg_color"] = args["bg_color"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getImageQrcodeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/qrcode";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) query["text"] = args["text"];
            if (args != null && args.ContainsKey("size")) query["size"] = args["size"];
            if (args != null && args.ContainsKey("format")) query["format"] = args["format"];
            if (args != null && args.ContainsKey("transparent")) query["transparent"] = args["transparent"];
            if (args != null && args.ContainsKey("fgcolor")) query["fgcolor"] = args["fgcolor"];
            if (args != null && args.ContainsKey("bgcolor")) query["bgcolor"] = args["bgcolor"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getImageTobase64Async(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/tobase64";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("url")) query["url"] = args["url"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postImageCompressAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/compress";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("level")) query["level"] = args["level"];
            if (args != null && args.ContainsKey("format")) query["format"] = args["format"];
            if (args != null && args.ContainsKey("file")) body["file"] = args["file"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postImageFrombase64Async(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/frombase64";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("imageData")) body["imageData"] = args["imageData"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postImageMotouAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/motou";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("bg_color")) body["bg_color"] = args["bg_color"];
            if (args != null && args.ContainsKey("file")) body["file"] = args["file"];
            if (args != null && args.ContainsKey("image_url")) body["image_url"] = args["image_url"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postImageNsfwAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/nsfw";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("file")) body["file"] = args["file"];
            if (args != null && args.ContainsKey("url")) body["url"] = args["url"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postImageSpeechlessAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/speechless";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("bottom_text")) body["bottom_text"] = args["bottom_text"];
            if (args != null && args.ContainsKey("top_text")) body["top_text"] = args["top_text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postImageSvgAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/image/svg";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("format")) query["format"] = args["format"];
            if (args != null && args.ContainsKey("width")) query["width"] = args["width"];
            if (args != null && args.ContainsKey("height")) query["height"] = args["height"];
            if (args != null && args.ContainsKey("quality")) query["quality"] = args["quality"];
            if (args != null && args.ContainsKey("file")) body["file"] = args["file"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public MiscApi Misc => new MiscApi(this);
    public class MiscApi {
        private readonly Client _c; public MiscApi(Client c) { _c = c; }
        public Task<object?> getHistoryProgrammerAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/history/programmer";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("month")) query["month"] = args["month"];
            if (args != null && args.ContainsKey("day")) query["day"] = args["day"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getHistoryProgrammerTodayAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/history/programmer/today";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscDistrictAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/district";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("keywords")) query["keywords"] = args["keywords"];
            if (args != null && args.ContainsKey("adcode")) query["adcode"] = args["adcode"];
            if (args != null && args.ContainsKey("lat")) query["lat"] = args["lat"];
            if (args != null && args.ContainsKey("lng")) query["lng"] = args["lng"];
            if (args != null && args.ContainsKey("level")) query["level"] = args["level"];
            if (args != null && args.ContainsKey("country")) query["country"] = args["country"];
            if (args != null && args.ContainsKey("limit")) query["limit"] = args["limit"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscHolidayCalendarAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/holiday-calendar";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("date")) query["date"] = args["date"];
            if (args != null && args.ContainsKey("month")) query["month"] = args["month"];
            if (args != null && args.ContainsKey("year")) query["year"] = args["year"];
            if (args != null && args.ContainsKey("timezone")) query["timezone"] = args["timezone"];
            if (args != null && args.ContainsKey("holiday_type")) query["holiday_type"] = args["holiday_type"];
            if (args != null && args.ContainsKey("include_nearby")) query["include_nearby"] = args["include_nearby"];
            if (args != null && args.ContainsKey("nearby_limit")) query["nearby_limit"] = args["nearby_limit"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscHotboardAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/hotboard";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("type")) query["type"] = args["type"];
            if (args != null && args.ContainsKey("time")) query["time"] = args["time"];
            if (args != null && args.ContainsKey("keyword")) query["keyword"] = args["keyword"];
            if (args != null && args.ContainsKey("time_start")) query["time_start"] = args["time_start"];
            if (args != null && args.ContainsKey("time_end")) query["time_end"] = args["time_end"];
            if (args != null && args.ContainsKey("limit")) query["limit"] = args["limit"];
            if (args != null && args.ContainsKey("sources")) query["sources"] = args["sources"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscLunartimeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/lunartime";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("ts")) query["ts"] = args["ts"];
            if (args != null && args.ContainsKey("timezone")) query["timezone"] = args["timezone"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscPhoneinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/phoneinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("phone")) query["phone"] = args["phone"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscRandomnumberAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/randomnumber";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("min")) query["min"] = args["min"];
            if (args != null && args.ContainsKey("max")) query["max"] = args["max"];
            if (args != null && args.ContainsKey("count")) query["count"] = args["count"];
            if (args != null && args.ContainsKey("allow_repeat")) query["allow_repeat"] = args["allow_repeat"];
            if (args != null && args.ContainsKey("allow_decimal")) query["allow_decimal"] = args["allow_decimal"];
            if (args != null && args.ContainsKey("decimal_places")) query["decimal_places"] = args["decimal_places"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscTimestampAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/timestamp";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("ts")) query["ts"] = args["ts"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscTrackingCarriersAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/tracking/carriers";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscTrackingDetectAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/tracking/detect";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("tracking_number")) query["tracking_number"] = args["tracking_number"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscTrackingQueryAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/tracking/query";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("tracking_number")) query["tracking_number"] = args["tracking_number"];
            if (args != null && args.ContainsKey("carrier_code")) query["carrier_code"] = args["carrier_code"];
            if (args != null && args.ContainsKey("phone")) query["phone"] = args["phone"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscWeatherAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/weather";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("city")) query["city"] = args["city"];
            if (args != null && args.ContainsKey("adcode")) query["adcode"] = args["adcode"];
            if (args != null && args.ContainsKey("extended")) query["extended"] = args["extended"];
            if (args != null && args.ContainsKey("forecast")) query["forecast"] = args["forecast"];
            if (args != null && args.ContainsKey("hourly")) query["hourly"] = args["hourly"];
            if (args != null && args.ContainsKey("minutely")) query["minutely"] = args["minutely"];
            if (args != null && args.ContainsKey("indices")) query["indices"] = args["indices"];
            if (args != null && args.ContainsKey("lang")) query["lang"] = args["lang"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscWorldtimeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/worldtime";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("city")) query["city"] = args["city"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postMiscDateDiffAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/date-diff";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("end_date")) body["end_date"] = args["end_date"];
            if (args != null && args.ContainsKey("format")) body["format"] = args["format"];
            if (args != null && args.ContainsKey("start_date")) body["start_date"] = args["start_date"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public NetworkApi Network => new NetworkApi(this);
    public class NetworkApi {
        private readonly Client _c; public NetworkApi(Client c) { _c = c; }
        public Task<object?> getNetworkDnsAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/dns";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("domain")) query["domain"] = args["domain"];
            if (args != null && args.ContainsKey("type")) query["type"] = args["type"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkIcpAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/icp";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("domain")) query["domain"] = args["domain"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkIpinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/ipinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("ip")) query["ip"] = args["ip"];
            if (args != null && args.ContainsKey("source")) query["source"] = args["source"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkMyipAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/myip";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("source")) query["source"] = args["source"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkPingAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/ping";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("host")) query["host"] = args["host"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkPingmyipAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/pingmyip";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkPortscanAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/portscan";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("host")) query["host"] = args["host"];
            if (args != null && args.ContainsKey("port")) query["port"] = args["port"];
            if (args != null && args.ContainsKey("protocol")) query["protocol"] = args["protocol"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkUrlstatusAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/urlstatus";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("url")) query["url"] = args["url"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkWhoisAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/whois";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("domain")) query["domain"] = args["domain"];
            if (args != null && args.ContainsKey("format")) query["format"] = args["format"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getNetworkWxdomainAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/network/wxdomain";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("domain")) query["domain"] = args["domain"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public PoemApi Poem => new PoemApi(this);
    public class PoemApi {
        private readonly Client _c; public PoemApi(Client c) { _c = c; }
        public Task<object?> getSayingAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/saying";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public RandomApi Random => new RandomApi(this);
    public class RandomApi {
        private readonly Client _c; public RandomApi(Client c) { _c = c; }
        public Task<object?> getAnswerbookAskAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/answerbook/ask";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("question")) query["question"] = args["question"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getRandomImageAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/random/image";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("category")) query["category"] = args["category"];
            if (args != null && args.ContainsKey("type")) query["type"] = args["type"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getRandomStringAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/random/string";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("length")) query["length"] = args["length"];
            if (args != null && args.ContainsKey("type")) query["type"] = args["type"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postAnswerbookAskAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/answerbook/ask";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("question")) body["question"] = args["question"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public SocialApi Social => new SocialApi(this);
    public class SocialApi {
        private readonly Client _c; public SocialApi(Client c) { _c = c; }
        public Task<object?> getGithubRepoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/github/repo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("repo")) query["repo"] = args["repo"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialBilibiliArchivesAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/bilibili/archives";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("mid")) query["mid"] = args["mid"];
            if (args != null && args.ContainsKey("keywords")) query["keywords"] = args["keywords"];
            if (args != null && args.ContainsKey("orderby")) query["orderby"] = args["orderby"];
            if (args != null && args.ContainsKey("ps")) query["ps"] = args["ps"];
            if (args != null && args.ContainsKey("pn")) query["pn"] = args["pn"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialBilibiliLiveroomAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/bilibili/liveroom";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("mid")) query["mid"] = args["mid"];
            if (args != null && args.ContainsKey("room_id")) query["room_id"] = args["room_id"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialBilibiliRepliesAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/bilibili/replies";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("oid")) query["oid"] = args["oid"];
            if (args != null && args.ContainsKey("sort")) query["sort"] = args["sort"];
            if (args != null && args.ContainsKey("ps")) query["ps"] = args["ps"];
            if (args != null && args.ContainsKey("pn")) query["pn"] = args["pn"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialBilibiliUserinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/bilibili/userinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("uid")) query["uid"] = args["uid"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialBilibiliVideoinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/bilibili/videoinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("aid")) query["aid"] = args["aid"];
            if (args != null && args.ContainsKey("bvid")) query["bvid"] = args["bvid"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialQqGroupinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/qq/groupinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("group_id")) query["group_id"] = args["group_id"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getSocialQqUserinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/social/qq/userinfo";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("qq")) query["qq"] = args["qq"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public StatusApi Status => new StatusApi(this);
    public class StatusApi {
        private readonly Client _c; public StatusApi(Client c) { _c = c; }
        public Task<object?> getStatusRatelimitAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/status/ratelimit";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getStatusUsageAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/status/usage";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("path")) query["path"] = args["path"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public TextApi Text => new TextApi(this);
    public class TextApi {
        private readonly Client _c; public TextApi(Client c) { _c = c; }
        public Task<object?> getTextMd5Async(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/md5";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) query["text"] = args["text"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextAesDecryptAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/aes/decrypt";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("key")) body["key"] = args["key"];
            if (args != null && args.ContainsKey("nonce")) body["nonce"] = args["nonce"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextAesDecryptAdvancedAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/aes/decrypt-advanced";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("iv")) body["iv"] = args["iv"];
            if (args != null && args.ContainsKey("key")) body["key"] = args["key"];
            if (args != null && args.ContainsKey("mode")) body["mode"] = args["mode"];
            if (args != null && args.ContainsKey("padding")) body["padding"] = args["padding"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextAesEncryptAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/aes/encrypt";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("key")) body["key"] = args["key"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextAesEncryptAdvancedAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/aes/encrypt-advanced";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("iv")) body["iv"] = args["iv"];
            if (args != null && args.ContainsKey("key")) body["key"] = args["key"];
            if (args != null && args.ContainsKey("mode")) body["mode"] = args["mode"];
            if (args != null && args.ContainsKey("output_format")) body["output_format"] = args["output_format"];
            if (args != null && args.ContainsKey("padding")) body["padding"] = args["padding"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextAnalyzeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/analyze";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextBase64DecodeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/base64/decode";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextBase64EncodeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/base64/encode";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextConvertAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/convert";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("from")) body["from"] = args["from"];
            if (args != null && args.ContainsKey("options")) body["options"] = args["options"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            if (args != null && args.ContainsKey("to")) body["to"] = args["to"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextMd5Async(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/md5";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTextMd5VerifyAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/md5/verify";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("hash")) body["hash"] = args["hash"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public TranslateApi Translate => new TranslateApi(this);
    public class TranslateApi {
        private readonly Client _c; public TranslateApi(Client c) { _c = c; }
        public Task<object?> getAiTranslateLanguagesAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/ai/translate/languages";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postAiTranslateAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/ai/translate";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("target_lang")) query["target_lang"] = args["target_lang"];
            if (args != null && args.ContainsKey("context")) body["context"] = args["context"];
            if (args != null && args.ContainsKey("preserve_format")) body["preserve_format"] = args["preserve_format"];
            if (args != null && args.ContainsKey("source_lang")) body["source_lang"] = args["source_lang"];
            if (args != null && args.ContainsKey("style")) body["style"] = args["style"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTranslateStreamAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/translate/stream";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("from_lang")) body["from_lang"] = args["from_lang"];
            if (args != null && args.ContainsKey("query")) body["query"] = args["query"];
            if (args != null && args.ContainsKey("to_lang")) body["to_lang"] = args["to_lang"];
            if (args != null && args.ContainsKey("tone")) body["tone"] = args["tone"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postTranslateTextAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/translate/text";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("to_lang")) query["to_lang"] = args["to_lang"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public WebparseApi Webparse => new WebparseApi(this);
    public class WebparseApi {
        private readonly Client _c; public WebparseApi(Client c) { _c = c; }
        public Task<object?> getWebTomarkdownAsyncStatusAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/web/tomarkdown/async/{task_id}";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("task_id") && args["task_id"] != null) path = path.Replace("{"+ "task_id" +"}", args["task_id"]!.ToString());
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getWebparseExtractimagesAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/webparse/extractimages";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("url")) query["url"] = args["url"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getWebparseMetadataAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/webparse/metadata";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("url")) query["url"] = args["url"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postWebTomarkdownAsyncAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/web/tomarkdown/async";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("url")) query["url"] = args["url"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public MinGanCiShiBieApi MinGanCiShiBie => new MinGanCiShiBieApi(this);
    public class MinGanCiShiBieApi {
        private readonly Client _c; public MinGanCiShiBieApi(Client c) { _c = c; }
        public Task<object?> getSensitiveWordAnalyzeQueryAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/sensitive-word/analyze-query";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("keyword")) query["keyword"] = args["keyword"];
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postSensitiveWordAnalyzeAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/sensitive-word/analyze";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("keywords")) body["keywords"] = args["keywords"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postSensitiveWordQuickCheckAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/text/profanitycheck";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
    public ZhiNengSouSuoApi ZhiNengSouSuo => new ZhiNengSouSuoApi(this);
    public class ZhiNengSouSuoApi {
        private readonly Client _c; public ZhiNengSouSuoApi(Client c) { _c = c; }
        public Task<object?> getSearchEnginesAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/search/engines";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> postSearchAggregateAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/search/aggregate";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("fetch_full")) body["fetch_full"] = args["fetch_full"];
            if (args != null && args.ContainsKey("filetype")) body["filetype"] = args["filetype"];
            if (args != null && args.ContainsKey("query")) body["query"] = args["query"];
            if (args != null && args.ContainsKey("site")) body["site"] = args["site"];
            if (args != null && args.ContainsKey("sort")) body["sort"] = args["sort"];
            if (args != null && args.ContainsKey("time_range")) body["time_range"] = args["time_range"];
            if (args != null && args.ContainsKey("timeout_ms")) body["timeout_ms"] = args["timeout_ms"];
            return _c.RequestAsync("POST", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
    }
}
