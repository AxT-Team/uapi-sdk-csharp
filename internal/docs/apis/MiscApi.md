# uapi-sdk-csharp.Api.MiscApi

All URIs are relative to *https://uapis.cn*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetHistoryProgrammer**](MiscApi.md#gethistoryprogrammer) | **GET** /history/programmer | 程序员历史事件 |
| [**GetHistoryProgrammerToday**](MiscApi.md#gethistoryprogrammertoday) | **GET** /history/programmer/today | 程序员历史上的今天 |
| [**GetMiscDistrict**](MiscApi.md#getmiscdistrict) | **GET** /misc/district | Adcode 国内外行政区域查询 |
| [**GetMiscHolidayCalendar**](MiscApi.md#getmischolidaycalendar) | **GET** /misc/holiday-calendar | 查询节假日与万年历 |
| [**GetMiscHotboard**](MiscApi.md#getmischotboard) | **GET** /misc/hotboard | 查询热榜 |
| [**GetMiscLunartime**](MiscApi.md#getmisclunartime) | **GET** /misc/lunartime | 查询农历时间 |
| [**GetMiscMovieBoxOffice**](MiscApi.md#getmiscmovieboxoffice) | **GET** /misc/movie-box-office | 查询电影票房 |
| [**GetMiscMovieRatingRank**](MiscApi.md#getmiscmovieratingrank) | **GET** /misc/movie-rating-rank | 电影收视排行查询 |
| [**GetMiscPhoneinfo**](MiscApi.md#getmiscphoneinfo) | **GET** /misc/phoneinfo | 查询手机归属地 |
| [**GetMiscRandomnumber**](MiscApi.md#getmiscrandomnumber) | **GET** /misc/randomnumber | 随机数生成 |
| [**GetMiscTimestamp**](MiscApi.md#getmisctimestamp) | **GET** /misc/timestamp | 转换时间戳 (旧版，推荐使用/convert/unixtime) |
| [**GetMiscTrackingCarriers**](MiscApi.md#getmisctrackingcarriers) | **GET** /misc/tracking/carriers | 获取支持的快递公司列表 |
| [**GetMiscTrackingDetect**](MiscApi.md#getmisctrackingdetect) | **GET** /misc/tracking/detect | 识别快递公司 |
| [**GetMiscTrackingQuery**](MiscApi.md#getmisctrackingquery) | **GET** /misc/tracking/query | 查询快递物流信息 |
| [**GetMiscWeather**](MiscApi.md#getmiscweather) | **GET** /misc/weather | 查询天气 |
| [**GetMiscWeatherHistory**](MiscApi.md#getmiscweatherhistory) | **GET** /misc/weather/history | 查询历史天气 |
| [**GetMiscWorldtime**](MiscApi.md#getmiscworldtime) | **GET** /misc/worldtime | 查询世界时间 |
| [**PostMiscDateDiff**](MiscApi.md#postmiscdatediff) | **POST** /misc/date-diff | 计算两个日期之间的时间差值 |

<a id="gethistoryprogrammer"></a>
# **GetHistoryProgrammer**
> GetHistoryProgrammer200Response GetHistoryProgrammer (int month, int day)

程序员历史事件

想查看程序员历史上某个特定日期发生的大事件？指定月份和日期，我们就能告诉你！  ## 功能概述 通过指定月份和日期，获取该日发生的程序员相关历史事件。同样使用AI智能筛选，确保事件的相关性和重要性。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **month** | **int** | 月份，1-12之间的整数。 |  |
| **day** | **int** | 日期，1-31之间的整数。 |  |

### Return type

[**GetHistoryProgrammer200Response**](GetHistoryProgrammer200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 获取成功！返回指定日期的程序员历史事件列表。 |  -  |
| **400** | 请求参数错误。请检查月份和日期参数是否正确。 |  -  |
| **500** | 服务器内部错误。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="gethistoryprogrammertoday"></a>
# **GetHistoryProgrammerToday**
> GetHistoryProgrammerToday200Response GetHistoryProgrammerToday ()

程序员历史上的今天

想知道程序员历史上的今天发生了什么大事吗？这个接口告诉你答案！  ## 功能概述 我们使用AI智能筛选从海量历史事件中挑选出与程序员、计算机科学相关的重要事件。每个事件都经过重要性评分和相关性评分，确保内容质量。


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetHistoryProgrammerToday200Response**](GetHistoryProgrammerToday200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 获取成功！返回今天的程序员历史事件列表。 |  -  |
| **500** | 服务器内部错误。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscdistrict"></a>
# **GetMiscDistrict**
> GetMiscDistrict200Response GetMiscDistrict (string keywords = null, string adcode = null, decimal lat = null, decimal lng = null, string level = null, string country = null, int limit = null)

Adcode 国内外行政区域查询

一个接口，覆盖全球 243 个国家、中国省/市/区/街道四级行政区划，支持关键词搜索、行政编码查询、坐标反查三种查询模式（必须至少传入一种查询参数）。  ## 功能概述 根据用户输入的搜索条件快速查找行政区域信息。例如：中国 > 山东省 > 济南市 > 历下区 > 舜华路街道。  无需注册、无需密钥，直接调用即可获取结构化的行政区域数据。支持三种查询方式： - 传 `adcode`，按行政编码精确查询，同时返回下级区划列表 - 传 `lat` + `lng`，坐标反查附近地点 - 传 `keywords`，按关键词搜索，支持中英文  ## 中国与国际数据差异 中国数据包含 `adcode`、`citycode` 等字段，支持省/市/区/街道四级逐级查询；国际城市数据不含这些字段，但额外提供 `population`（人口）和 `timezone`（时区）。  > [!NOTE] > 部分城市（如东莞、文昌）没有区县层级，市级下方直接显示街道。街道级别的 `adcode` 返回的是所属区县的 `adcode`。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **keywords** | **string** | 关键词搜索（城市名、区县名，支持中英文）。 | [optional]  |
| **adcode** | **string** | 中国行政区划代码精确查询（如 &#x60;110000&#x60;），同时返回下级行政区。 | [optional]  |
| **lat** | **decimal** | 纬度，与 &#x60;lng&#x60; 配合使用，坐标反查附近地点。 | [optional]  |
| **lng** | **decimal** | 经度，与 &#x60;lat&#x60; 配合使用。 | [optional]  |
| **level** | **string** | 过滤行政级别。 | [optional]  |
| **country** | **string** | 过滤国家代码（ISO 3166-1 alpha-2），如 &#x60;CN&#x60;、&#x60;JP&#x60;、&#x60;US&#x60;、&#x60;GB&#x60;。 | [optional]  |
| **limit** | **int** | 返回数量上限，默认 &#x60;20&#x60;，最大 &#x60;100&#x60;。 | [optional] [default to 20] |

### Return type

[**GetMiscDistrict200Response**](GetMiscDistrict200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！返回匹配的行政区域列表。 |  -  |
| **400** | 请求参数错误。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmischolidaycalendar"></a>
# **GetMiscHolidayCalendar**
> GetMiscHolidayCalendar200Response GetMiscHolidayCalendar (string date = null, string month = null, string year = null, string timezone = null, string holidayType = null, bool includeNearby = null, int nearbyLimit = null, bool excludePast = null)

查询节假日与万年历

查询指定日期、月份或年份的万年历与节假日信息。  ## 功能概述 这个接口支持三种查询方式：按天（`date`）、按月（`month`）和按年（`year`）。调用时三者选一个传入即可。  如果你只关心某一类事件，可以通过 `holiday_type` 进行筛选，例如只看法定休假/调休、公历节日、农历节日或节气。  在 `date` 模式下，传 `include_nearby=true` 可以额外返回该日期前后最近的节日；返回数量由 `nearby_limit` 控制，默认 7，最大 30。  如果你只想保留今天和之后的节日，可以再传 `exclude_past=true` 过滤已经过去的节日。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **string** | 按天查询时填写这个参数，例如查某一天。格式：&#x60;YYYY-MM-DD&#x60;。和 &#x60;month&#x60;、&#x60;year&#x60; 三选一。 | [optional]  |
| **month** | **string** | 按月查询时填写这个参数，例如查某个月。格式：&#x60;YYYY-MM&#x60;。和 &#x60;date&#x60;、&#x60;year&#x60; 三选一。 | [optional]  |
| **year** | **string** | 按年查询时填写这个参数，例如查某一年。格式：&#x60;YYYY&#x60;。和 &#x60;date&#x60;、&#x60;month&#x60; 三选一。 | [optional]  |
| **timezone** | **string** | 时区名称，默认 Asia/Shanghai。 | [optional] [default to &quot;Asia/Shanghai&quot;] |
| **holidayType** | **string** | 节日筛选类型，默认 all。 | [optional] [default to all] |
| **includeNearby** | **bool** | 是否返回前后最近节日，仅 date 模式生效，默认 false。month/year 模式会忽略此参数。 | [optional] [default to false] |
| **nearbyLimit** | **int** | 返回最近节日数量限制，默认 7，最大 30。仅 date 模式 + include_nearby&#x3D;true 生效。 | [optional] [default to 7] |
| **excludePast** | **bool** | 传 true 时，会过滤今天之前已经过去的节日。默认 false。 | [optional] [default to false] |

### Return type

[**GetMiscHolidayCalendar200Response**](GetMiscHolidayCalendar200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功，返回指定范围的万年历与节假日信息。 |  -  |
| **400** | 请求参数错误。常见原因： - &#x60;date&#x60;、&#x60;month&#x60;、&#x60;year&#x60; 未传或同时传入多个 - 日期格式错误：&#x60;date&#x60; 必须为 &#x60;YYYY-MM-DD&#x60;、&#x60;month&#x60; 必须为 &#x60;YYYY-MM&#x60;、&#x60;year&#x60; 必须为 &#x60;YYYY&#x60; - &#x60;holiday_type&#x60; 非法 - &#x60;timezone&#x60; 非法 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmischotboard"></a>
# **GetMiscHotboard**
> GetMiscHotboard200Response GetMiscHotboard (string type, long time = null, string keyword = null, long timeStart = null, long timeEnd = null, int limit = null)

查询热榜

想快速跟上网络热点？这个接口让你一网打尽各大主流平台的实时热榜/热搜！  ## 功能概述 你只需要指定一个平台类型，就能获取到该平台当前的热榜数据列表。每个热榜条目都包含标题、热度值和原始链接。非常适合用于制作信息聚合类应用或看板。  ## 三种使用模式  ### 默认模式 只传 `type` 参数，返回该平台当前的实时热榜。  ### 时光机模式 传 `type` + `time` 参数，返回指定时间附近最近可展示的历史热榜快照。  ### 搜索模式 传 `type` + `keyword` + `time_start` + `time_end` 参数，在指定历史时间范围内搜索包含关键词的热榜条目。可选传 `limit` 限制返回数量。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **type** | **string** | 你想要查询的热榜平台。请从[支持的平台列表](#enum-list)中选择。 |  |
| **time** | **long** | 时光机模式：毫秒时间戳，返回该时间附近最近可展示的历史热榜快照。不传则返回当前实时热榜。 | [optional]  |
| **keyword** | **string** | 搜索模式：搜索关键词，在指定历史时间范围内搜索包含该关键词的条目。需配合 time_start 和 time_end 使用。 | [optional]  |
| **timeStart** | **long** | 搜索模式必填：搜索起始时间戳（毫秒），需位于该平台历史数据覆盖范围内。 | [optional]  |
| **timeEnd** | **long** | 搜索模式必填：搜索结束时间戳（毫秒），需晚于 time_start 且位于该平台历史数据覆盖范围内。 | [optional]  |
| **limit** | **int** | 搜索模式下最大返回条数，默认 50，最大 200。 | [optional]  |

### Return type

[**GetMiscHotboard200Response**](GetMiscHotboard200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！返回指定平台的热榜列表数据。不同模式返回格式不同：默认模式和时光机模式返回 list 数组；搜索模式返回 results 数组。 |  -  |
| **400** | 请求参数错误。你提供的 &#x60;type&#x60; 参数不是我们支持的平台类型，请检查拼写。 |  -  |
| **500** | 获取热榜失败。服务器在处理数据时发生内部错误。 |  -  |
| **502** | 暂时无法获取相关数据，请稍后重试。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmisclunartime"></a>
# **GetMiscLunartime**
> GetMiscLunartime200Response GetMiscLunartime (string ts = null, string timezone = null)

查询农历时间

需要在指定时区下查看某个时间点的农历信息？这个接口可以直接返回完整结果。  ## 功能概述 支持传入 Unix 时间戳（秒或毫秒）和 IANA 时区名，返回公历时间、星期、农历年月日、干支、生肖、节气与节日信息。不传 `ts` 时默认使用当前时间，不传 `timezone` 时默认 `Asia/Shanghai`。  ## 时区说明 - 支持标准 IANA 时区，例如 `Asia/Shanghai`、`Asia/Tokyo` - 也支持别名：`Shanghai`、`Beijing` - 时区非法时返回 400 并提示 `invalid timezone: xxx`


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **ts** | **string** | Unix 时间戳，支持 10 位秒级或 13 位毫秒级。不传则默认当前时间。 | [optional]  |
| **timezone** | **string** | 时区名称。支持 IANA 时区（如 Asia/Shanghai）和别名（Shanghai、Beijing）。默认 Asia/Shanghai。 | [optional]  |

### Return type

[**GetMiscLunartime200Response**](GetMiscLunartime200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功，返回指定时间和时区下的农历信息。 |  -  |
| **400** | 请求参数错误。&#x60;timezone&#x60; 非法时返回 &#x60;invalid timezone: xxx&#x60;，&#x60;ts&#x60; 非法时返回 &#x60;invalid timestamp: xxx&#x60;。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscmovieboxoffice"></a>
# **GetMiscMovieBoxOffice**
> GetMiscMovieBoxOffice200Response GetMiscMovieBoxOffice ()

查询电影票房

正在做影视类应用，想直观展示今天哪部电影最卖座？大盘总票房突破了多少？这个接口能帮你实时获取院线大盘和影片票房排名。  ## 功能概述 调用此接口，无需任何参数，即可获取当前实时的电影市场大盘数据（包含总票房、总场次、总人次），以及每一部上映影片的具体表现（包括票房明细、排片占比、上座率、场均人次和累计票房等）。


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetMiscMovieBoxOffice200Response**](GetMiscMovieBoxOffice200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！返回实时大盘汇总及影片排行榜列表。 |  -  |
| **503** | 上游实时票房数据不可用或发生拥堵。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscmovieratingrank"></a>
# **GetMiscMovieRatingRank**
> GetMiscMovieRatingRank200Response GetMiscMovieRatingRank (string channel = null, string platform = null, int limit = null, string period = null, string date = null)

电影收视排行查询

想做影视榜单页或选题分析？这个接口提供影视的收视、热度和评分排行，既能查实时榜，也能按日、周、月回看历史快照。  ## 功能概述 用 `channel` 切换全网、卫视、网络平台或院线榜单，用 `period` + `date` 查询历史日榜、周榜和月榜。适合影视资讯页、数据看板、自媒体选题和内容运营分析。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channel** | **string** | 渠道：all（全网）、tv（卫视）、web（网络平台）、cinema（院线），默认 all。 | [optional] [default to all] |
| **platform** | **string** | 按渠道或平台关键字过滤，例如 卫视、爱奇艺。 | [optional]  |
| **limit** | **int** | 每个渠道仅返回前 N 条。 | [optional]  |
| **period** | **string** | 排行周期：realtime、day、week、month，默认 realtime。 | [optional] [default to realtime] |
| **date** | **string** | 历史快照日期，格式 YYYY-MM-DD；用于 day/week/month。 | [optional]  |

### Return type

[**GetMiscMovieRatingRank200Response**](GetMiscMovieRatingRank200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功，返回影视排行数据。 |  -  |
| **400** | 参数错误，例如 period 不是 realtime/day/week/month。 |  -  |
| **404** | 指定日期或周期暂无历史快照数据。 |  -  |
| **503** | 服务暂时不可用，请稍后重试。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscphoneinfo"></a>
# **GetMiscPhoneinfo**
> GetMiscPhoneinfo200Response GetMiscPhoneinfo (string phone)

查询手机归属地

想知道一个手机号码来自哪里？是移动、联通还是电信？这个接口可以告诉你答案。  ## 功能概述 提供一个国内的手机号码，我们会查询并返回它的归属地（省份和城市）以及所属的运营商信息。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **phone** | **string** | 需要查询的11位中国大陆手机号码。 |  |

### Return type

[**GetMiscPhoneinfo200Response**](GetMiscPhoneinfo200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！返回号码的归属地和运营商信息。 |  -  |
| **400** | 请求参数错误。请检查你是否提供了 &#x60;phone&#x60; 参数，以及它是否是有效的11位手机号码。 |  -  |
| **500** | 查询失败。我们的号码归属地数据库可能暂时无法访问，请稍后重试。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscrandomnumber"></a>
# **GetMiscRandomnumber**
> GetMiscRandomnumber200Response GetMiscRandomnumber (int min = null, int max = null, int count = null, bool allowRepeat = null, bool allowDecimal = null, int decimalPlaces = null)

随机数生成

需要一个简单的随机数，还是需要一串不重复的、带小数的随机数？这个接口都能满足你！  ## 功能概述 这是一个强大的随机数生成器。你可以指定生成的范围（最大/最小值）、数量、是否允许重复、以及是否生成小数（并指定小数位数）。  ## 使用须知 > [!WARNING] > **不重复生成的逻辑限制** > 当设置 `allow_repeat=false` 时，请确保取值范围 `(max - min + 1)` 大于或等于你请求的数量 `count`。否则，系统将无法生成足够的不重复数字，请求会失败并返回 400 错误。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **min** | **int** | 生成随机数的最小值（包含）。 | [optional] [default to 1] |
| **max** | **int** | 生成随机数的最大值（包含）。 | [optional] [default to 100] |
| **count** | **int** | 需要生成的随机数的数量。 | [optional] [default to 1] |
| **allowRepeat** | **bool** | 是否允许生成的多个数字中出现重复值。 | [optional] [default to false] |
| **allowDecimal** | **bool** | 是否生成小（浮点）数。如果为 false，则只生成整数。 | [optional] [default to false] |
| **decimalPlaces** | **int** | 如果 &#x60;allow_decimal&#x3D;true&#x60;，这里可以指定小数的位数。 | [optional] [default to 2] |

### Return type

[**GetMiscRandomnumber200Response**](GetMiscRandomnumber200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 生成成功！返回一个包含随机数的数组。 |  -  |
| **400** | 请求参数无效。例如，&#x60;min&#x60; 大于 &#x60;max&#x60;，或者在不允许重复的情况下，请求的数量大于可能生成的数字总数。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmisctimestamp"></a>
# **GetMiscTimestamp**
> GetMiscTimestamp200Response GetMiscTimestamp (string ts)

转换时间戳 (旧版，推荐使用/convert/unixtime)

这是一个用于将Unix时间戳转换为人类可读日期时间的旧版接口。  ## 功能概述 输入一个秒级或毫秒级的时间戳，返回其对应的本地时间和UTC时间。  > [!WARNING] > **接口已过时**：这个接口已被新的 `/convert/unixtime` 取代。新接口功能更强大，支持双向转换。我们建议你迁移到新接口。  [➡️ 前往新版接口文档](/docs/api-reference/get-convert-unixtime)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **ts** | **string** | 需要转换的Unix时间戳，支持10位（秒）或13位（毫秒）。 |  |

### Return type

[**GetMiscTimestamp200Response**](GetMiscTimestamp200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 转换成功！ |  -  |
| **400** | 无效的时间戳参数。请检查 &#x60;ts&#x60; 参数是否为纯数字字符串。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmisctrackingcarriers"></a>
# **GetMiscTrackingCarriers**
> GetMiscTrackingCarriers200Response GetMiscTrackingCarriers ()

获取支持的快递公司列表

不确定系统支持哪些快递公司？这个接口返回完整的支持列表。  ## 功能概述 获取系统当前支持的所有快递公司列表，包括每家公司的标准编码（code）和中文名称（name）。  ## 使用建议 - **推荐缓存**：这个列表基本不会频繁变动，建议在应用启动时调用一次并缓存到本地 - **应用场景**：适合用于构建快递公司选择器、下拉菜单等UI组件 - **缓存时长**：建议缓存24小时或更久


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetMiscTrackingCarriers200Response**](GetMiscTrackingCarriers200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 获取成功！返回所有支持的快递公司列表。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmisctrackingdetect"></a>
# **GetMiscTrackingDetect**
> GetMiscTrackingDetect200Response GetMiscTrackingDetect (string trackingNumber)

识别快递公司

不确定手里的快递单号属于哪家快递公司？这个接口专门做识别，不查物流。  ## 功能概述 输入快递单号，系统会根据单号规则快速识别出最可能的快递公司。如果存在多个可能的匹配结果，还会在 `alternatives` 字段中返回备选项，供你参考选择。  ## 使用须知 - **识别速度快**：只做规则匹配，不查询物流信息，响应速度通常在100ms内 - **准确率高**：基于各快递公司的单号规则进行智能识别，准确率超过95% - **备选方案**：当单号规则可能匹配多家快递公司时，会提供所有可能的选项


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **trackingNumber** | **string** | 需要识别的快递单号。 |  |

### Return type

[**GetMiscTrackingDetect200Response**](GetMiscTrackingDetect200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 识别成功！直接返回识别结果和可能的备选项。 |  -  |
| **404** | 无法识别该快递单号。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmisctrackingquery"></a>
# **GetMiscTrackingQuery**
> GetMiscTrackingQuery200Response GetMiscTrackingQuery (string trackingNumber, string carrierCode = null, string phone = null)

查询快递物流信息

买了东西想知道快递到哪儿了？这个接口帮你实时追踪物流状态。  ## 功能概述 提供一个快递单号，系统会自动识别快递公司并返回完整的物流轨迹信息。这个接口目前可以查询中通、圆通、韵达、申通、极兔、顺丰、京东、EMS、德邦等主流快递公司的物流信息。  ## 使用须知 - **自动识别**：不知道是哪家快递？系统会根据单号规则自动识别快递公司（推荐使用） - **手动指定**：如果已知快递公司，可以传递 `carrier_code` 参数，查询速度会更快 - **手机尾号验证**：顺丰等部分快递公司需要验证收件人手机尾号才能查询详细物流，如果返回 `暂无物流信息`，建议尝试传入 `phone` 参数 - **查询时效**：物流信息实时查询，响应时间通常在1-2秒内


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **trackingNumber** | **string** | 快递单号，通常是一串10-20位的数字或字母数字组合。 |  |
| **carrierCode** | **string** | 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。 | [optional]  |
| **phone** | **string** | 收件人手机尾号，4位数字（可选）。部分快递公司需要验证手机尾号才能查询详细物流信息。 | [optional]  |

### Return type

[**GetMiscTrackingQuery200Response**](GetMiscTrackingQuery200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！直接返回快递的完整物流轨迹。 |  -  |
| **400** | 参数错误，请检查快递单号是否正确。 |  -  |
| **404** | 当前没有查询到物流轨迹时会返回 404，并附带错误码和提示信息。如果返回此错误，建议尝试传入 &#x60;phone&#x60; 参数（收件人手机尾号）再次查询。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscweather"></a>
# **GetMiscWeather**
> GetMiscWeather200Response GetMiscWeather (string city = null, string adcode = null, bool extended = null, bool forecast = null, bool hourly = null, bool minutely = null, bool indices = null, string lang = null)

查询天气

出门前，查一下天气总是个好习惯。这个接口为你提供精准、实时的天气数据，支持国内和国际城市。  ## 功能概述 这个接口支持三种查询方式： - 可以传 `adcode`，按行政区编码查询（优先级最高） - 可以传 `city`，按城市名称查询，支持中文（`北京`）和英文（`Tokyo`） - 两个都不传时，按客户端 IP 自动定位查询  支持 `lang` 参数，可选 `zh`（默认）和 `en`，城市名翻译覆盖 7000+ 城市。  ## 可选功能模块 - `extended=true`：扩展气象字段（体感温度、能见度、气压、紫外线、空气质量及污染物分项数据） - `forecast=true`：多天预报（最多7天，会额外返回每天的最高温度、最低温度，以及日出日落、风速等详细数据） - `hourly=true`：逐小时预报（24小时） - `minutely=true`：分钟级降水预报（仅国内城市，精确到2分钟） - `indices=true`：18项生活指数（穿衣、紫外线、洗车、运动、花粉等）  ## 天气字段说明 `weather` 是天气现象文本，不是固定枚举。  常见值包括：晴、多云、阴、小雨、中雨、大雨、雷阵雨、小雪、中雪、大雪、雨夹雪、雾、霾、沙尘。  如果你的业务需要稳定的天气分类，建议使用 `weather_code` 进行映射。完整的天气图标代码请参考[天气图标代码表](#enum-list)。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **city** | **string** | 城市名称，支持中文（&#x60;北京&#x60;）和英文（&#x60;Tokyo&#x60;）。可选参数，不传时会尝试 IP 自动定位。 | [optional]  |
| **adcode** | **string** | 城市行政区划代码（如 &#x60;110000&#x60;），优先级高于 city。可选参数，不传时会尝试 IP 自动定位。 | [optional]  |
| **extended** | **bool** | 返回扩展气象字段（体感温度、能见度、气压、紫外线、降水量、云量、空气质量指数及污染物分项数据）。 | [optional]  |
| **forecast** | **bool** | 返回多天预报数据（最多7天），含每天的最高温度、最低温度、白天夜间天气、风向风力、日出日落等。 | [optional]  |
| **hourly** | **bool** | 返回逐小时预报（24小时），含温度、天气、风向风速、湿度、降水概率等。 | [optional]  |
| **minutely** | **bool** | 返回分钟级降水预报（仅国内城市），精确到2分钟。 | [optional]  |
| **indices** | **bool** | 返回18项生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度、出行、钓鱼、过敏、防晒、心情、啤酒、雨伞、交通、空气净化器、花粉）。 | [optional]  |
| **lang** | **string** | 返回语言。&#x60;zh&#x60; 返回中文（默认），&#x60;en&#x60; 返回英文。城市名翻译覆盖 7000+ 城市。生活指数（&#x60;indices&#x60;）目前仅支持中文。 | [optional] [default to zh] |

### Return type

[**GetMiscWeather200Response**](GetMiscWeather200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！返回该地区的实时天气信息。 |  -  |
| **400** | 参数无效。常见原因：&#x60;adcode&#x60; 格式非法、&#x60;lang&#x60; 非法（仅支持 zh/en）、参数值类型错误或参数组合无效。 |  -  |
| **404** | 城市未找到。 |  -  |
| **500** | 服务器内部错误。 |  -  |
| **503** | 天气服务暂时不可用。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscweatherhistory"></a>
# **GetMiscWeatherHistory**
> GetMiscWeatherHistory200Response GetMiscWeatherHistory (string city = null, string adcode = null, string startDate = null, string endDate = null, int days = null, string lang = null)

查询历史天气

想知道某个城市过去一段时间有没有下雨、降雨量是多少？这个接口用于查询过去最多 366 天的城市每日历史天气。  ## 功能概述 支持按 `city`、`adcode` 或客户端 IP 自动定位查询。你可以传 `start_date` + `end_date` 指定日期范围，也可以只传 `days` 回看最近若干天。返回结果重点包含 `rained` 与 `rain`，适合做出行复盘、农业记录、气象看板和数据分析。  ## 使用须知 > [!NOTE] > 定位优先级：`adcode` > `city` > IP 自动定位。同时传 `start_date` 和 `days` 时，以 `start_date` + `end_date` 区间为准。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **city** | **string** | 城市名称，支持中文或英文；可选，不传 city/adcode 时会尝试 IP 自动定位。 | [optional]  |
| **adcode** | **string** | 6 位行政区划代码，优先级高于 city。 | [optional]  |
| **startDate** | **string** | 起始日期，格式 YYYY-MM-DD；与 end_date 搭配使用。 | [optional]  |
| **endDate** | **string** | 结束日期，格式 YYYY-MM-DD，默认昨天。 | [optional]  |
| **days** | **int** | 回看天数，1-366，默认 365；仅在未指定 start_date 时生效。 | [optional] [default to 365] |
| **lang** | **string** | 返回语言：zh（默认）或 en。 | [optional] [default to zh] |

### Return type

[**GetMiscWeatherHistory200Response**](GetMiscWeatherHistory200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功，返回城市历史每日天气。 |  -  |
| **400** | 参数错误，例如日期格式不正确或 lang 不是 zh/en。 |  -  |
| **404** | 未找到城市位置。 |  -  |
| **502** | 服务暂时不可用，请稍后重试。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmiscworldtime"></a>
# **GetMiscWorldtime**
> GetMiscWorldtime200Response GetMiscWorldtime (string city)

查询世界时间

需要和国外的朋友开会，想知道他那边现在几点？用这个接口一查便知。  ## 功能概述 根据标准的时区名称（例如 'Asia/Shanghai' 或 'Europe/London'），获取该时区的当前准确时间、UTC偏移量、星期等信息。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **city** | **string** | 你需要查询的城市或地区。请从[支持的时区列表](#enum-list)中选择标准 IANA 时区名称，例如 &#39;Asia/Shanghai&#39;, &#39;Asia/Tokyo&#39;, &#39;America/New_York&#39;。 |  |

### Return type

[**GetMiscWorldtime200Response**](GetMiscWorldtime200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 查询成功！返回指定时区的详细时间信息。 |  -  |
| **400** | 请求参数错误。请检查你是否提供了 &#x60;city&#x60; 参数。 |  -  |
| **404** | 时区未找到。根据你提供的名称，未能找到对应的时区。请检查拼写或使用标准的 &#39;洲/城市&#39; 格式。 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="postmiscdatediff"></a>
# **PostMiscDateDiff**
> PostMiscDateDiff200Response PostMiscDateDiff (PostMiscDateDiffRequest postMiscDateDiffRequest)

计算两个日期之间的时间差值

想知道两个日期之间相差多久？这个接口帮你精确计算时间差值。  ## 功能概述 输入开始日期和结束日期，返回它们之间的时间差，包括总天数、总小时数、总分钟数、总秒数、总周数，以及人性化显示格式（如\"1年2月3天\"）。  ## 日期格式 接口支持自动识别常见日期格式，包括：YYYY-MM-DD、YYYY/MM/DD、DD-MM-YYYY、ISO 8601（带时区）等。也可以通过`format`参数显式指定格式（如DD-MM-YYYY）。  > [!NOTE] > 当结束日期早于开始日期时，返回的数值为负数。


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **postMiscDateDiffRequest** | [**PostMiscDateDiffRequest**](PostMiscDateDiffRequest.md) |  |  |

### Return type

[**PostMiscDateDiff200Response**](PostMiscDateDiff200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | 计算成功，返回多种单位的时间差值 |  -  |
| **400** | 日期解析失败或参数错误 |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

