# uapi-sdk-csharp.Model.PostAiTranslate200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **int** |  | [optional] 
**Message** | **string** |  | [optional] 
**IsBatch** | **bool** | 标识是否为批量翻译请求。 | [optional] 
**Data** | [**PostAiTranslate200ResponseData**](PostAiTranslate200ResponseData.md) |  | [optional] 
**BatchData** | [**List&lt;PostAiTranslate200ResponseBatchDataInner&gt;**](PostAiTranslate200ResponseBatchDataInner.md) | 批量翻译结果列表，仅在批量翻译时返回。 | [optional] 
**BatchSummary** | [**PostAiTranslate200ResponseBatchSummary**](PostAiTranslate200ResponseBatchSummary.md) |  | [optional] 
**Performance** | [**PostAiTranslate200ResponsePerformance**](PostAiTranslate200ResponsePerformance.md) |  | [optional] 
**QualityMetrics** | [**PostAiTranslate200ResponseQualityMetrics**](PostAiTranslate200ResponseQualityMetrics.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

