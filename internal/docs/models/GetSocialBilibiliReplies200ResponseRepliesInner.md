# uapi-sdk-csharp.Model.GetSocialBilibiliReplies200ResponseRepliesInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Rpid** | **decimal** | 评论的唯一ID (Reply ID)。 | [optional] 
**Oid** | **decimal** | 评论区对象ID，即视频的aid。 | [optional] 
**Mid** | **decimal** | 发表评论的用户的mid。 | [optional] 
**Root** | **decimal** | 根评论的rpid。如果为0，表示这条评论是根评论。 | [optional] 
**Parent** | **decimal** | 回复的父级评论的rpid。如果为0，表示是根评论。 | [optional] 
**Count** | **decimal** | 这条评论下的回复（楼中楼）数量。 | [optional] 
**Ctime** | **decimal** | 评论发送时间的Unix时间戳（秒）。 | [optional] 
**Like** | **decimal** | 该评论获得的点赞数。 | [optional] 
**Member** | [**GetSocialBilibiliReplies200ResponseRepliesInnerMember**](GetSocialBilibiliReplies200ResponseRepliesInnerMember.md) |  | [optional] 
**Content** | [**GetSocialBilibiliReplies200ResponseRepliesInnerContent**](GetSocialBilibiliReplies200ResponseRepliesInnerContent.md) |  | [optional] 
**Replies** | **List&lt;Object&gt;** | 楼中楼回复列表。结构与顶层评论对象一致，但通常此数组为空，需要单独请求。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

