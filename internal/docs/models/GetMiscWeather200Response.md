# uapi-sdk-csharp.Model.GetMiscWeather200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Province** | **string** | 省份 | [optional] 
**City** | **string** | 城市名 | [optional] 
**District** | **string** | 区县或更细一级的行政区名称。自动按 IP 定位时更常见。 | [optional] 
**Adcode** | **string** | 行政区划代码（部分数据源可能为空） | [optional] 
**Weather** | **string** | 天气状况描述。默认返回中文，传 &#x60;lang&#x3D;en&#x60; 时返回英文。非固定枚举。 | [optional] 
**WeatherIcon** | **string** | 天气图标代码。请从[天气图标代码表](#enum-list)中查看所有可能的值。 | [optional] 
**Temperature** | **decimal** | 当前温度 °C | [optional] 
**WindDirection** | **string** | 风向 | [optional] 
**WindPower** | **string** | 风力等级 | [optional] 
**Humidity** | **decimal** | 相对湿度 % | [optional] 
**ReportTime** | **string** | 数据更新时间 | [optional] 
**FeelsLike** | **decimal** | 体感温度 °C（extended&#x3D;true 时返回） | [optional] 
**Visibility** | **decimal** | 能见度 km（extended&#x3D;true 时返回） | [optional] 
**Pressure** | **decimal** | 气压 hPa（extended&#x3D;true 时返回） | [optional] 
**Uv** | **decimal** | 紫外线指数（extended&#x3D;true 时返回） | [optional] 
**Precipitation** | **decimal** | 当前降水量 mm（extended&#x3D;true 时返回） | [optional] 
**Cloud** | **decimal** | 云量 %（extended&#x3D;true 时返回） | [optional] 
**Aqi** | **decimal** | 空气质量指数 0-500（extended&#x3D;true 时返回） | [optional] 
**AqiLevel** | **decimal** | AQI 等级 1-6（extended&#x3D;true 时返回） | [optional] 
**AqiCategory** | **string** | AQI 等级描述（优/良/轻度污染/中度污染/重度污染/严重污染）（extended&#x3D;true 时返回） | [optional] 
**AqiPrimary** | **string** | 主要污染物（如 PM2.5、PM10、O3 等）（extended&#x3D;true 时返回） | [optional] 
**AirPollutants** | [**GetMiscWeather200ResponseAirPollutants**](GetMiscWeather200ResponseAirPollutants.md) |  | [optional] 
**TempMax** | **decimal** | 当天最高温 °C（forecast&#x3D;true 时返回） | [optional] 
**TempMin** | **decimal** | 当天最低温 °C（forecast&#x3D;true 时返回） | [optional] 
**Forecast** | [**List&lt;GetMiscWeather200ResponseForecastInner&gt;**](GetMiscWeather200ResponseForecastInner.md) | 多天天气预报，最多7天（forecast&#x3D;true 时返回） | [optional] 
**HourlyForecast** | [**List&lt;GetMiscWeather200ResponseHourlyForecastInner&gt;**](GetMiscWeather200ResponseHourlyForecastInner.md) | 逐小时预报，最多24小时（hourly&#x3D;true 时返回） | [optional] 
**MinutelyPrecip** | [**GetMiscWeather200ResponseMinutelyPrecip**](GetMiscWeather200ResponseMinutelyPrecip.md) |  | [optional] 
**LifeIndices** | [**GetMiscWeather200ResponseLifeIndices**](GetMiscWeather200ResponseLifeIndices.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

