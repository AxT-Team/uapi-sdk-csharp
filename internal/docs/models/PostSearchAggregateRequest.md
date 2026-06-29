# uapi-sdk-csharp.Model.PostSearchAggregateRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Query** | **string** | 搜索查询关键词，支持中英文 | 
**FetchFull** | **bool** | 是否获取页面完整正文（会影响响应时间） | [optional] [default to false]
**Filetype** | **string** | 限制文件类型，不需要 &#x60;filetype:&#x60; 前缀。支持 pdf、doc、docx、ppt、pptx、xls、xlsx、txt 等 | [optional] 
**Site** | **string** | 限制搜索特定网站，不需要 &#x60;site:&#x60; 前缀 | [optional] 
**Sort** | **string** | 排序方式 | [optional] [default to SortEnum.Relevance]
**TimeRange** | **string** | 时间范围过滤 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

