# uapi-sdk-csharp.Model.PostSearchAggregate200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Metadata** | [**PostSearchAggregate200ResponseMetadata**](PostSearchAggregate200ResponseMetadata.md) |  | [optional] 
**ProcessTimeMs** | **int** | 本次请求总耗时（毫秒） | [optional] 
**Query** | **string** | 执行的搜索查询 | [optional] 
**Results** | [**List&lt;PostSearchAggregate200ResponseResultsInner&gt;**](PostSearchAggregate200ResponseResultsInner.md) | 搜索结果列表 | [optional] 
**Sources** | [**List&lt;PostSearchAggregate200ResponseSourcesInner&gt;**](PostSearchAggregate200ResponseSourcesInner.md) | 本次请求实际命中的搜索引擎信息 | [optional] 
**TotalResults** | **int** | 返回的搜索结果总数 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

