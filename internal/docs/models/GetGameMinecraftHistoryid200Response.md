# uapi-sdk-csharp.Model.GetGameMinecraftHistoryid200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **int** | 状态码，200代表成功。 | [optional] 
**History** | [**List&lt;GetGameMinecraftHistoryid200ResponseHistoryInner&gt;**](GetGameMinecraftHistoryid200ResponseHistoryInner.md) | 一个包含所有历史用户名的数组，按时间倒序排列。 | [optional] 
**Id** | **string** | 玩家当前的用户名。 | [optional] 
**NameNum** | **int** | 历史名称的总数（包含当前名称）。 | [optional] 
**Uuid** | **string** | 被查询玩家的32位无破折号UUID。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

