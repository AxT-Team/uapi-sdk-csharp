# uapi-sdk-csharp.Model.GetSocialBilibiliVideoinfo200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Bvid** | **string** | 稿件的BV号。 | [optional] 
**Aid** | **decimal** | 稿件的AV号。 | [optional] 
**Videos** | **decimal** | 稿件分P总数。如果是单P视频，则为1。 | [optional] 
**Tname** | **string** | 视频所属的子分区名称。 | [optional] 
**Copyright** | **decimal** | 视频类型。1代表原创，2代表转载。 | [optional] 
**Pic** | **string** | 稿件封面图片的URL。这是一个可以直接在网页上展示的链接。 | [optional] 
**Title** | **string** | 稿件的标题。 | [optional] 
**Pubdate** | **decimal** | 稿件发布时间的Unix时间戳（秒）。 | [optional] 
**Ctime** | **decimal** | 用户投稿时间的Unix时间戳（秒）。 | [optional] 
**Desc** | **string** | 视频简介。可能会包含HTML换行符。 | [optional] 
**Duration** | **decimal** | 稿件总时长（所有分P累加），单位为秒。 | [optional] 
**Owner** | [**GetSocialBilibiliVideoinfo200ResponseOwner**](GetSocialBilibiliVideoinfo200ResponseOwner.md) |  | [optional] 
**Stat** | [**GetSocialBilibiliVideoinfo200ResponseStat**](GetSocialBilibiliVideoinfo200ResponseStat.md) |  | [optional] 
**Pages** | [**List&lt;GetSocialBilibiliVideoinfo200ResponsePagesInner&gt;**](GetSocialBilibiliVideoinfo200ResponsePagesInner.md) | 视频分P列表。即使是单P视频，该数组也包含一个元素。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

