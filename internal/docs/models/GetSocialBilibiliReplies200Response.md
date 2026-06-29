# uapi-sdk-csharp.Model.GetSocialBilibiliReplies200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Config** | **Object** | 评论区配置。不同视频或不同权限下可能为 null。 | [optional] 
**Control** | **Object** | 评论区控制信息。没有数据时为 null。 | [optional] 
**Cursor** | **Object** | 游标翻页信息。部分场景下为 null。 | [optional] 
**Folder** | **Object** | 评论折叠相关信息。没有数据时为 null。 | [optional] 
**Hots** | **List&lt;Object&gt;** | 热门评论列表。结构与 &#x60;replies&#x60; 中的对象一致。如果当前页是第一页，且有热门评论，则此数组非空。 | [optional] 
**Notice** | **Object** | 评论区公告信息。没有公告时为 null。 | [optional] 
**Page** | [**GetSocialBilibiliReplies200ResponsePage**](GetSocialBilibiliReplies200ResponsePage.md) |  | [optional] 
**Replies** | [**List&lt;GetSocialBilibiliReplies200ResponseRepliesInner&gt;**](GetSocialBilibiliReplies200ResponseRepliesInner.md) | 当前页的评论列表。 | [optional] 
**Top** | **Object** | 置顶评论信息。没有置顶评论时为 null。 | [optional] 
**Upper** | **Object** | UP 主相关信息。无数据时为 null。 | [optional] 
**Vote** | **decimal** | 评论区投票相关状态值。没有投票时通常为 0。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

