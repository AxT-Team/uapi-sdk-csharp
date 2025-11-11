# uapi-sdk-csharp.Model.PostSearchAggregate200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Query** | **string** | 实际执行的搜索查询 | [optional] 
**TotalResults** | **int** | 搜索结果总数 | [optional] 
**Results** | [**List&lt;PostSearchAggregate200ResponseResultsInner&gt;**](PostSearchAggregate200ResponseResultsInner.md) | 搜索结果列表 | [optional] 
**Sources** | [**List&lt;PostSearchAggregate200ResponseSourcesInner&gt;**](PostSearchAggregate200ResponseSourcesInner.md) | 各搜索引擎的结果数量统计 | [optional] 
**ProcessTimeMs** | **int** | 处理耗时（毫秒） | [optional] 
**Cached** | **bool** | 结果是否来自缓存 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

