# uapi-sdk-csharp.Model.DailyRecommendMoment
包装对象。外层字段随 mode 不同而不同，语录本体统一放在 item 中。

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentTime** | **string** | 仅 moment 模式返回，服务器当前时间，ISO 8601 格式。 | [optional] 
**Date** | **string** | 仅 daily 模式返回，对应日期，格式 YYYY-MM-DD。 | [optional] 
**Item** | [**DailyRecommendMomentItem**](DailyRecommendMomentItem.md) |  | [optional] 
**Mode** | **string** | 当前运行模式。 | [optional] 
**Scene** | [**DailyRecommendMomentScene**](DailyRecommendMomentScene.md) |  | [optional] 
**Seed** | **string** | 当次结果的确定性种子。 | [optional] 
**TimeSegment** | **string** | 仅 moment 模式返回，命中的时段标识。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

