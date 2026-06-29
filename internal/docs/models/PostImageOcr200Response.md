# uapi-sdk-csharp.Model.PostImageOcr200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Blocks** | **List&lt;Object&gt;** | 按块组织的详细识别结果。 | [optional] 
**Image** | **Object** | 图片本身的基础信息。 | [optional] 
**Lines** | **List&lt;Object&gt;** | 按行组织的详细识别结果。 | [optional] 
**Markdown** | **string** | 根据图片中的标题、段落和表格整理出的 Markdown 文本。只有在 &#x60;return_markdown&#x3D;true&#x60; 时才会返回。 | [optional] 
**NeedLocation** | **bool** | 本次响应是否包含坐标信息。 | [optional] 
**Pages** | **List&lt;Object&gt;** | 按页组织的详细识别结果。 | [optional] 
**PlainText** | **string** | 纯文本结果，适合做搜索、索引或直接展示。 | [optional] 
**Raw** | **Object** | 补充识别结果对象，适合需要继续解析更多细节字段的场景。 | [optional] 
**Summary** | **Object** | 识别结果的统计摘要。 | [optional] 
**Text** | **string** | 按阅读顺序拼接后的识别文本。 | [optional] 
**Timing** | **Object** | 耗时拆分信息，适合做性能统计或排查。 | [optional] 
**WordsResult** | [**List&lt;PostImageOcr200ResponseWordsResultInner&gt;**](PostImageOcr200ResponseWordsResultInner.md) | 逐段文字结果。适合做高亮、框选和逐项解析。 | [optional] 
**WordsResultNum** | **int** | 识别出的文字片段数量。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

