# uapi-sdk-csharp.Model.GetSocialBilibiliVideoinfo200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Bvid** | **string** | 稿件的BV号。 | [optional] 
**Aid** | **decimal** | 稿件的AV号。 | [optional] 
**Videos** | **decimal** | 稿件分P总数。如果是单P视频，则为1。 | [optional] 
**Tid** | **decimal** | 视频所属的子分区 ID。 | [optional] 
**Tname** | **string** | 视频所属的子分区名称。 | [optional] 
**Copyright** | **decimal** | 视频类型。1代表原创，2代表转载。 | [optional] 
**Pic** | **string** | 稿件封面图片的URL。这是一个可以直接在网页上展示的链接。 | [optional] 
**Title** | **string** | 稿件的标题。 | [optional] 
**Pubdate** | **decimal** | 稿件发布时间的Unix时间戳（秒）。 | [optional] 
**Ctime** | **decimal** | 用户投稿时间的Unix时间戳（秒）。 | [optional] 
**Desc** | **string** | 视频简介。可能会包含HTML换行符。 | [optional] 
**DescV2** | [**List&lt;GetSocialBilibiliVideoinfo200ResponseDescV2Inner&gt;**](GetSocialBilibiliVideoinfo200ResponseDescV2Inner.md) | 结构化简介片段。 | [optional] 
**State** | **decimal** | 视频状态码。 | [optional] 
**Duration** | **decimal** | 稿件总时长（所有分P累加），单位为秒。 | [optional] 
**Rights** | [**GetSocialBilibiliVideoinfo200ResponseRights**](GetSocialBilibiliVideoinfo200ResponseRights.md) |  | [optional] 
**Owner** | [**GetSocialBilibiliVideoinfo200ResponseOwner**](GetSocialBilibiliVideoinfo200ResponseOwner.md) |  | [optional] 
**Stat** | [**GetSocialBilibiliVideoinfo200ResponseStat**](GetSocialBilibiliVideoinfo200ResponseStat.md) |  | [optional] 
**Dynamic** | **string** | 投稿时附带的动态文字。 | [optional] 
**Cid** | **decimal** | 主分P的 CID（弹幕 ID）。 | [optional] 
**Dimension** | [**GetSocialBilibiliVideoinfo200ResponseDimension**](GetSocialBilibiliVideoinfo200ResponseDimension.md) |  | [optional] 
**NoCache** | **bool** | 不缓存标记。 | [optional] 
**Pages** | [**List&lt;GetSocialBilibiliVideoinfo200ResponsePagesInner&gt;**](GetSocialBilibiliVideoinfo200ResponsePagesInner.md) | 视频分P列表。即使是单P视频，该数组也包含一个元素。 | [optional] 
**Subtitle** | [**GetSocialBilibiliVideoinfo200ResponseSubtitle**](GetSocialBilibiliVideoinfo200ResponseSubtitle.md) |  | [optional] 
**Staff** | [**List&lt;GetSocialBilibiliVideoinfo200ResponseStaffInner&gt;**](GetSocialBilibiliVideoinfo200ResponseStaffInner.md) | 联合投稿成员列表。 | [optional] 
**UgcSeason** | [**GetSocialBilibiliVideoinfo200ResponseUgcSeason**](GetSocialBilibiliVideoinfo200ResponseUgcSeason.md) |  | [optional] 
**IsChargeableSeason** | **bool** | 是否为付费合集。 | [optional] 
**IsStory** | **bool** | 是否为剧情类视频。 | [optional] 
**HonorReply** | [**GetSocialBilibiliVideoinfo200ResponseHonorReply**](GetSocialBilibiliVideoinfo200ResponseHonorReply.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

