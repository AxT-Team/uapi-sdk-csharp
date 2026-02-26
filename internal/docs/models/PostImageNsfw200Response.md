# uapi-sdk-csharp.Model.PostImageNsfw200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NsfwScore** | **decimal** | NSFW 内容的置信度分数，范围 0-1，越高表示越可能是敏感内容。 | [optional] 
**NormalScore** | **decimal** | 正常内容的置信度分数，范围 0-1。 | [optional] 
**IsNsfw** | **bool** | 是否判定为 NSFW 内容。 | [optional] 
**Label** | **string** | 内容标签，&#39;nsfw&#39; 或 &#39;normal&#39;。 | [optional] 
**Suggestion** | **string** | 处理建议：&#39;pass&#39;（通过）、&#39;review&#39;（人工复核）、&#39;block&#39;（拦截）。 | [optional] 
**RiskLevel** | **string** | 风险等级：&#39;low&#39;、&#39;medium&#39;、&#39;high&#39;。 | [optional] 
**Confidence** | **decimal** | 模型对当前判断的置信度。 | [optional] 
**InferenceTimeMs** | **decimal** | 模型推理耗时，单位毫秒。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

