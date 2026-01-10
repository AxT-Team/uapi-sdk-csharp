using System.Net.Http.Json;

namespace uapi;

public class UapiError: Exception {
    public string Code { get; }
    public int Status { get; }
    public object? Details { get; }
    public UapiError(string code, int status, string message, object? details = null) : base($"[{status}] {code}: {message}") { Code = code; Status = status; Details = details; }
}

public class ApiErrorError: UapiError { public ApiErrorError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class AvatarNotFoundError: UapiError { public AvatarNotFoundError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class ConversionFailedError: UapiError { public ConversionFailedError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class FileOpenErrorError: UapiError { public FileOpenErrorError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class FileRequiredError: UapiError { public FileRequiredError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class InternalServerErrorError: UapiError { public InternalServerErrorError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class InvalidParameterError: UapiError { public InvalidParameterError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class InvalidParamsError: UapiError { public InvalidParamsError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class NotFoundError: UapiError { public NotFoundError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class NoMatchError: UapiError { public NoMatchError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class NoTrackingDataError: UapiError { public NoTrackingDataError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class PhoneInfoFailedError: UapiError { public PhoneInfoFailedError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class RecognitionFailedError: UapiError { public RecognitionFailedError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class RequestEntityTooLargeError: UapiError { public RequestEntityTooLargeError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class ServiceBusyError: UapiError { public ServiceBusyError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class TimezoneNotFoundError: UapiError { public TimezoneNotFoundError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class UnauthorizedError: UapiError { public UnauthorizedError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class UnsupportedCarrierError: UapiError { public UnsupportedCarrierError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }
public class UnsupportedFormatError: UapiError { public UnsupportedFormatError(string code, int status, string message, object? details = null) : base(code,status,message,details) {} }


public class Client {
    private readonly HttpClient _http;
    public Client(string baseUrl, string? token = null) {
        var normalized = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
        _http = new HttpClient { BaseAddress = new Uri(normalized) };
        if (!string.IsNullOrEmpty(token)) _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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
        if (!res.IsSuccessStatusCode) {
            var json = await res.Content.ReadFromJsonAsync<Dictionary<string,object?>>();
            var code = (json != null && json.TryGetValue("code", out var c) && c is string) ? ((string)c).ToUpper() : DefaultCode((int)res.StatusCode);
            var message = (json != null && json.TryGetValue("message", out var m) && m is string) ? (string)m : res.ReasonPhrase ?? "";
            throw From(code, (int)res.StatusCode, message, json != null && json.TryGetValue("details", out var d) ? d : null);
        }
        var ct = res.Content.Headers.ContentType?.MediaType ?? "";
        if (ct.Contains("json")) return await res.Content.ReadFromJsonAsync<object>();
        return await res.Content.ReadAsStringAsync();
    }
    private static string DefaultCode(int status) => status switch {
        400 => "INVALID_PARAMETER", 401 => "UNAUTHORIZED", 404 => "NOT_FOUND", 429 => "SERVICE_BUSY", 500 => "INTERNAL_SERVER_ERROR", _ => "API_ERROR",
    };
    private static UapiError From(string code, int status, string message, object? details) => code switch {
        "API_ERROR" => new ApiErrorError(code, status, message, details),
        "AVATAR_NOT_FOUND" => new AvatarNotFoundError(code, status, message, details),
        "CONVERSION_FAILED" => new ConversionFailedError(code, status, message, details),
        "FILE_OPEN_ERROR" => new FileOpenErrorError(code, status, message, details),
        "FILE_REQUIRED" => new FileRequiredError(code, status, message, details),
        "INTERNAL_SERVER_ERROR" => new InternalServerErrorError(code, status, message, details),
        "INVALID_PARAMETER" => new InvalidParameterError(code, status, message, details),
        "INVALID_PARAMS" => new InvalidParamsError(code, status, message, details),
        "NOT_FOUND" => new NotFoundError(code, status, message, details),
        "NO_MATCH" => new NoMatchError(code, status, message, details),
        "NO_TRACKING_DATA" => new NoTrackingDataError(code, status, message, details),
        "PHONE_INFO_FAILED" => new PhoneInfoFailedError(code, status, message, details),
        "RECOGNITION_FAILED" => new RecognitionFailedError(code, status, message, details),
        "REQUEST_ENTITY_TOO_LARGE" => new RequestEntityTooLargeError(code, status, message, details),
        "SERVICE_BUSY" => new ServiceBusyError(code, status, message, details),
        "TIMEZONE_NOT_FOUND" => new TimezoneNotFoundError(code, status, message, details),
        "UNAUTHORIZED" => new UnauthorizedError(code, status, message, details),
        "UNSUPPORTED_CARRIER" => new UnsupportedCarrierError(code, status, message, details),
        "UNSUPPORTED_FORMAT" => new UnsupportedFormatError(code, status, message, details),
        _ => new UapiError(code,status,message,details)
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
        public Task<object?> getMiscHotboardAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/hotboard";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("type")) query["type"] = args["type"];
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
            return _c.RequestAsync("GET", path, query.Count > 0 ? query : null, body.Count > 0 ? body : null);
        }
        public Task<object?> getMiscWeatherAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/v1/misc/weather";
            var query = new Dictionary<string, object?>();
            var body = new Dictionary<string, object?>();
            if (args != null && args.ContainsKey("city")) query["city"] = args["city"];
            if (args != null && args.ContainsKey("adcode")) query["adcode"] = args["adcode"];
            if (args != null && args.ContainsKey("extended")) query["extended"] = args["extended"];
            if (args != null && args.ContainsKey("indices")) query["indices"] = args["indices"];
            if (args != null && args.ContainsKey("forecast")) query["forecast"] = args["forecast"];
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
            if (args != null && args.ContainsKey("fast_mode")) body["fast_mode"] = args["fast_mode"];
            if (args != null && args.ContainsKey("max_concurrency")) body["max_concurrency"] = args["max_concurrency"];
            if (args != null && args.ContainsKey("preserve_format")) body["preserve_format"] = args["preserve_format"];
            if (args != null && args.ContainsKey("source_lang")) body["source_lang"] = args["source_lang"];
            if (args != null && args.ContainsKey("style")) body["style"] = args["style"];
            if (args != null && args.ContainsKey("text")) body["text"] = args["text"];
            if (args != null && args.ContainsKey("texts")) body["texts"] = args["texts"];
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
