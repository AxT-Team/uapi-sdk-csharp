# uapi-sdk-csharp.Model.GetMiscLunartime200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Datetime** | **string** | 本地化时间，格式 YYYY-MM-DD HH:mm:ss。 | [optional] 
**DatetimeRfc3339** | **string** | RFC3339 时间格式。 | [optional] 
**GanzhiDay** | **string** | 干支日。 | [optional] 
**GanzhiMonth** | **string** | 干支月。 | [optional] 
**GanzhiYear** | **string** | 干支年。 | [optional] 
**IsLeapMonth** | **bool** | 是否闰月。 | [optional] 
**LunarDay** | **int** | 农历日期（数字）。 | [optional] 
**LunarDayCn** | **string** | 农历日期中文表示。 | [optional] 
**LunarFestivals** | **List&lt;string&gt;** | 农历节日数组。 | [optional] 
**LunarMonth** | **int** | 农历月份（数字）。 | [optional] 
**LunarMonthCn** | **string** | 农历月份中文表示。 | [optional] 
**LunarYear** | **int** | 农历年份（数字）。 | [optional] 
**LunarYearCn** | **string** | 农历年份中文表示。 | [optional] 
**QueryTimestamp** | **string** | 原始 ts 入参。 | [optional] 
**QueryTimezone** | **string** | 原始 timezone 入参。 | [optional] 
**SolarFestivals** | **List&lt;string&gt;** | 公历节日数组。 | [optional] 
**SolarTerm** | **string** | 节气名称。有值时返回，无值时可能为空字符串或不返回。 | [optional] 
**TimestampUnix** | **int** | 秒级 Unix 时间戳。 | [optional] 
**Timezone** | **string** | 解析后的时区。 | [optional] 
**Weekday** | **string** | 星期英文。 | [optional] 
**WeekdayCn** | **string** | 星期中文。 | [optional] 
**Zodiac** | **string** | 生肖。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

