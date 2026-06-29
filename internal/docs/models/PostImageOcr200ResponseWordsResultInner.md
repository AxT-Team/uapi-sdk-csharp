# uapi-sdk-csharp.Model.PostImageOcr200ResponseWordsResultInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Location** | [**PostImageOcr200ResponseWordsResultInnerLocation**](PostImageOcr200ResponseWordsResultInnerLocation.md) |  | [optional] 
**Score** | **decimal** | 当前文字片段的置信度。部分结果会返回。 | [optional] 
**VertexesLocation** | [**List&lt;PostImageOcr200ResponseWordsResultInnerVertexesLocationInner&gt;**](PostImageOcr200ResponseWordsResultInnerVertexesLocationInner.md) | 当前文字片段的顶点坐标列表。只有在 &#x60;need_location&#x3D;true&#x60; 时才会返回。 | [optional] 
**Words** | **string** | 当前文字片段的识别结果。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

