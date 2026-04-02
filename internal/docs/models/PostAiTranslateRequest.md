# uapi-sdk-csharp.Model.PostAiTranslateRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Text** | **string** | 待翻译的文本内容。最大长度10,000字符。 | 
**SourceLang** | **string** | 源语言代码，可选。如果不指定，系统会自动检测源语言。 | [optional] 
**Style** | **string** | 翻译风格，可选。支持casual(随意口语化)、professional(专业商务，默认)、academic(学术正式)、literary(文学艺术)。 | [optional] [default to StyleEnum.Professional]
**Context** | **string** | 翻译上下文场景，可选。支持general(通用，默认)、business(商务)、technical(技术)、medical(医疗)、legal(法律)、marketing(市场营销)、entertainment(娱乐)、education(教育)、news(新闻)。 | [optional] [default to ContextEnum.General]
**PreserveFormat** | **bool** | 是否保留原文格式，包括换行、缩进等。 | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

