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
        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        if (!string.IsNullOrEmpty(token)) _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }
    private async Task<object?> RequestAsync(string method, string path, Dictionary<string, object?>? query = null, object? body = null) {
        var uri = path + (query is null ? "" : "?" + string.Join("&", query.Select(kv => $"{kv.Key}={kv.Value}")));
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
            var path = "/api/get";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getClipzyRawAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/raw/{id}";
            if (args != null && args.ContainsKey("id") && args["id"] != null) path = path.Replace("{"+ "id" +"}", args["id"]!.ToString());
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postClipzyStoreAsync(Dictionary<string,object?>? args = null) {
            var path = "/api/store";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public ConvertApi Convert => new ConvertApi(this);
    public class ConvertApi {
        private readonly Client _c; public ConvertApi(Client c) { _c = c; }
        public Task<object?> getConvertUnixtimeAsync(Dictionary<string,object?>? args = null) {
            var path = "/convert/unixtime";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postConvertJsonAsync(Dictionary<string,object?>? args = null) {
            var path = "/convert/json";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public DailyApi Daily => new DailyApi(this);
    public class DailyApi {
        private readonly Client _c; public DailyApi(Client c) { _c = c; }
        public Task<object?> getDailyNewsImageAsync(Dictionary<string,object?>? args = null) {
            var path = "/daily/news-image";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public GameApi Game => new GameApi(this);
    public class GameApi {
        private readonly Client _c; public GameApi(Client c) { _c = c; }
        public Task<object?> getGameEpicFreeAsync(Dictionary<string,object?>? args = null) {
            var path = "/game/epic-free";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getGameMinecraftHistoryidAsync(Dictionary<string,object?>? args = null) {
            var path = "/game/minecraft/historyid";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getGameMinecraftServerstatusAsync(Dictionary<string,object?>? args = null) {
            var path = "/game/minecraft/serverstatus";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getGameMinecraftUserinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/game/minecraft/userinfo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getGameSteamSummaryAsync(Dictionary<string,object?>? args = null) {
            var path = "/game/steam/summary";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public ImageApi Image => new ImageApi(this);
    public class ImageApi {
        private readonly Client _c; public ImageApi(Client c) { _c = c; }
        public Task<object?> getAvatarGravatarAsync(Dictionary<string,object?>? args = null) {
            var path = "/avatar/gravatar";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getImageBingDailyAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/bing-daily";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getImageMotouAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/motou";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getImageQrcodeAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/qrcode";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getImageTobase64Async(Dictionary<string,object?>? args = null) {
            var path = "/image/tobase64";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postImageCompressAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/compress";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postImageFrombase64Async(Dictionary<string,object?>? args = null) {
            var path = "/image/frombase64";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postImageMotouAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/motou";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postImageSpeechlessAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/speechless";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postImageSvgAsync(Dictionary<string,object?>? args = null) {
            var path = "/image/svg";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public MiscApi Misc => new MiscApi(this);
    public class MiscApi {
        private readonly Client _c; public MiscApi(Client c) { _c = c; }
        public Task<object?> getHistoryProgrammerAsync(Dictionary<string,object?>? args = null) {
            var path = "/history/programmer";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getHistoryProgrammerTodayAsync(Dictionary<string,object?>? args = null) {
            var path = "/history/programmer/today";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscHotboardAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/hotboard";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscPhoneinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/phoneinfo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscRandomnumberAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/randomnumber";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscTimestampAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/timestamp";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscTrackingCarriersAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/tracking/carriers";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscTrackingDetectAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/tracking/detect";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscTrackingQueryAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/tracking/query";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscWeatherAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/weather";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getMiscWorldtimeAsync(Dictionary<string,object?>? args = null) {
            var path = "/misc/worldtime";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public NetworkApi Network => new NetworkApi(this);
    public class NetworkApi {
        private readonly Client _c; public NetworkApi(Client c) { _c = c; }
        public Task<object?> getNetworkDnsAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/dns";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkIcpAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/icp";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkIpinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/ipinfo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkMyipAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/myip";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkPingAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/ping";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkPingmyipAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/pingmyip";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkPortscanAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/portscan";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkUrlstatusAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/urlstatus";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkWhoisAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/whois";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getNetworkWxdomainAsync(Dictionary<string,object?>? args = null) {
            var path = "/network/wxdomain";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public PoemApi Poem => new PoemApi(this);
    public class PoemApi {
        private readonly Client _c; public PoemApi(Client c) { _c = c; }
        public Task<object?> getSayingAsync(Dictionary<string,object?>? args = null) {
            var path = "/saying";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public RandomApi Random => new RandomApi(this);
    public class RandomApi {
        private readonly Client _c; public RandomApi(Client c) { _c = c; }
        public Task<object?> getAnswerbookAskAsync(Dictionary<string,object?>? args = null) {
            var path = "/answerbook/ask";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getRandomImageAsync(Dictionary<string,object?>? args = null) {
            var path = "/random/image";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getRandomStringAsync(Dictionary<string,object?>? args = null) {
            var path = "/random/string";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postAnswerbookAskAsync(Dictionary<string,object?>? args = null) {
            var path = "/answerbook/ask";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public SocialApi Social => new SocialApi(this);
    public class SocialApi {
        private readonly Client _c; public SocialApi(Client c) { _c = c; }
        public Task<object?> getGithubRepoAsync(Dictionary<string,object?>? args = null) {
            var path = "/github/repo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialBilibiliArchivesAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/bilibili/archives";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialBilibiliLiveroomAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/bilibili/liveroom";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialBilibiliRepliesAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/bilibili/replies";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialBilibiliUserinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/bilibili/userinfo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialBilibiliVideoinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/bilibili/videoinfo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialQqGroupinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/qq/groupinfo";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getSocialQqUserinfoAsync(Dictionary<string,object?>? args = null) {
            var path = "/social/qq/userinfo";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public StatusApi Status => new StatusApi(this);
    public class StatusApi {
        private readonly Client _c; public StatusApi(Client c) { _c = c; }
        public Task<object?> getStatusRatelimitAsync(Dictionary<string,object?>? args = null) {
            var path = "/status/ratelimit";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getStatusUsageAsync(Dictionary<string,object?>? args = null) {
            var path = "/status/usage";
            return _c.RequestAsync("GET", path, args);
        }
    }
    public TextApi Text => new TextApi(this);
    public class TextApi {
        private readonly Client _c; public TextApi(Client c) { _c = c; }
        public Task<object?> getTextMd5Async(Dictionary<string,object?>? args = null) {
            var path = "/text/md5";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postTextAesDecryptAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/aes/decrypt";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTextAesEncryptAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/aes/encrypt";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTextAnalyzeAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/analyze";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTextBase64DecodeAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/base64/decode";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTextBase64EncodeAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/base64/encode";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTextMd5Async(Dictionary<string,object?>? args = null) {
            var path = "/text/md5";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTextMd5VerifyAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/md5/verify";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public TranslateApi Translate => new TranslateApi(this);
    public class TranslateApi {
        private readonly Client _c; public TranslateApi(Client c) { _c = c; }
        public Task<object?> getAiTranslateLanguagesAsync(Dictionary<string,object?>? args = null) {
            var path = "/ai/translate/languages";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postAiTranslateAsync(Dictionary<string,object?>? args = null) {
            var path = "/ai/translate";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postTranslateTextAsync(Dictionary<string,object?>? args = null) {
            var path = "/translate/text";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public WebparseApi Webparse => new WebparseApi(this);
    public class WebparseApi {
        private readonly Client _c; public WebparseApi(Client c) { _c = c; }
        public Task<object?> getWebTomarkdownAsyncStatusAsync(Dictionary<string,object?>? args = null) {
            var path = "/web/tomarkdown/async/{task_id}";
            if (args != null && args.ContainsKey("task_id") && args["task_id"] != null) path = path.Replace("{"+ "task_id" +"}", args["task_id"]!.ToString());
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getWebparseExtractimagesAsync(Dictionary<string,object?>? args = null) {
            var path = "/webparse/extractimages";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> getWebparseMetadataAsync(Dictionary<string,object?>? args = null) {
            var path = "/webparse/metadata";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postWebTomarkdownAsyncAsync(Dictionary<string,object?>? args = null) {
            var path = "/web/tomarkdown/async";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public MinGanCiShiBieApi MinGanCiShiBie => new MinGanCiShiBieApi(this);
    public class MinGanCiShiBieApi {
        private readonly Client _c; public MinGanCiShiBieApi(Client c) { _c = c; }
        public Task<object?> getSensitiveWordAnalyzeQueryAsync(Dictionary<string,object?>? args = null) {
            var path = "/sensitive-word/analyze-query";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postSensitiveWordAnalyzeAsync(Dictionary<string,object?>? args = null) {
            var path = "/sensitive-word/analyze";
            return _c.RequestAsync("POST", path, args);
        }
        public Task<object?> postSensitiveWordQuickCheckAsync(Dictionary<string,object?>? args = null) {
            var path = "/text/profanitycheck";
            return _c.RequestAsync("POST", path, args);
        }
    }
    public ZhiNengSouSuoApi ZhiNengSouSuo => new ZhiNengSouSuoApi(this);
    public class ZhiNengSouSuoApi {
        private readonly Client _c; public ZhiNengSouSuoApi(Client c) { _c = c; }
        public Task<object?> getSearchEnginesAsync(Dictionary<string,object?>? args = null) {
            var path = "/search/engines";
            return _c.RequestAsync("GET", path, args);
        }
        public Task<object?> postSearchAggregateAsync(Dictionary<string,object?>? args = null) {
            var path = "/search/aggregate";
            return _c.RequestAsync("POST", path, args);
        }
    }
}
