# uapi-sdk-csharp.Model.GetMiscHolidayCalendar200ResponseQuery
请求参数回显。

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Date** | **string** | 日视图查询参数。date 模式下为 YYYY-MM-DD，其余模式下为空字符串。 | [optional] 
**HolidayType** | **string** | 节日筛选类型。 | [optional] 
**IncludeNearby** | **bool** | 是否开启前后最近节日查询。 | [optional] 
**ExcludePast** | **bool** | 是否过滤今天之前已经过去的节日。 | [optional] 
**Month** | **string** | 月视图查询参数。month 模式下为 YYYY-MM，其余模式下为空字符串。 | [optional] 
**NearbyLimit** | **int** | 前后最近节日返回数量上限。 | [optional] 
**Timezone** | **string** | 实际生效的时区。 | [optional] 
**Year** | **string** | 年视图查询参数。year 模式下为 YYYY，其余模式下为空字符串。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

