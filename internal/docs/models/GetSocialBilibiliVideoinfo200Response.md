# uapi-sdk-csharp.Model.GetSocialBilibiliVideoinfo200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Aid** | **decimal** | 稿件的AV号。 | [optional] 
**Bvid** | **string** | 稿件的BV号。 | [optional] 
**Cid** | **decimal** | 主分P的 CID（弹幕 ID）。 | [optional] 
**Copyright** | **decimal** | 视频类型。1代表原创，2代表转载。 | [optional] 
**Ctime** | **decimal** | 用户投稿时间的Unix时间戳（秒）。 | [optional] 
**Desc** | **string** | 视频简介。可能会包含HTML换行符。 | [optional] 
**DescV2** | [**List&lt;GetSocialBilibiliVideoinfo200ResponseDescV2Inner&gt;**](GetSocialBilibiliVideoinfo200ResponseDescV2Inner.md) | 结构化简介片段。 | [optional] 
**Dimension** | [**GetSocialBilibiliVideoinfo200ResponseDimension**](GetSocialBilibiliVideoinfo200ResponseDimension.md) |  | [optional] 
**Duration** | **decimal** | 稿件总时长（所有分P累加），单位为秒。 | [optional] 
**Dynamic** | **string** | 投稿时附带的动态文字。 | [optional] 
**HonorReply** | [**GetSocialBilibiliVideoinfo200ResponseHonorReply**](GetSocialBilibiliVideoinfo200ResponseHonorReply.md) |  | [optional] 
**IsChargeableSeason** | **bool** | 是否为付费合集。 | [optional] 
**IsStory** | **bool** | 是否为剧情类视频。 | [optional] 
**IsUpowerExclusive** | **bool** | 是否为充电专属视频。该字段来自 B 站视频详情，用于区分普通免费视频和充电专属内容。 | [optional] 
**IsUpowerExclusiveWithQa** | **bool** | 是否为带问答/互动限制的充电专属视频。 | [optional] 
**IsUpowerPlay** | **bool** | 当前视频是否属于充电可播放状态。 | [optional] 
**IsUpowerPreview** | **bool** | 当前视频是否为充电专属试看状态。 | [optional] 
**NoCache** | **bool** | 不缓存标记。 | [optional] 
**Owner** | [**GetSocialBilibiliVideoinfo200ResponseOwner**](GetSocialBilibiliVideoinfo200ResponseOwner.md) |  | [optional] 
**Pages** | [**List&lt;GetSocialBilibiliVideoinfo200ResponsePagesInner&gt;**](GetSocialBilibiliVideoinfo200ResponsePagesInner.md) | 视频分P列表。即使是单P视频，该数组也包含一个元素。 | [optional] 
**PayType** | **string** | 归一化付费类型。可能值：free、upower_exclusive、upower、ugc_pay、pgc_pay。 | [optional] 
**Pic** | **string** | 稿件封面图片的URL。这是一个可以直接在网页上展示的链接。 | [optional] 
**Pubdate** | **decimal** | 稿件发布时间的Unix时间戳（秒）。 | [optional] 
**Rights** | [**GetSocialBilibiliVideoinfo200ResponseRights**](GetSocialBilibiliVideoinfo200ResponseRights.md) |  | [optional] 
**Staff** | [**List&lt;GetSocialBilibiliVideoinfo200ResponseStaffInner&gt;**](GetSocialBilibiliVideoinfo200ResponseStaffInner.md) | 联合投稿成员列表。 | [optional] 
**Stat** | [**GetSocialBilibiliVideoinfo200ResponseStat**](GetSocialBilibiliVideoinfo200ResponseStat.md) |  | [optional] 
**State** | **decimal** | 视频状态码。 | [optional] 
**Subtitle** | [**GetSocialBilibiliVideoinfo200ResponseSubtitle**](GetSocialBilibiliVideoinfo200ResponseSubtitle.md) |  | [optional] 
**Tid** | **decimal** | 视频所属的子分区 ID。 | [optional] 
**Title** | **string** | 稿件的标题。 | [optional] 
**Tname** | **string** | 视频所属的子分区名称。 | [optional] 
**UgcSeason** | [**GetSocialBilibiliVideoinfo200ResponseUgcSeason**](GetSocialBilibiliVideoinfo200ResponseUgcSeason.md) |  | [optional] 
**Videos** | **decimal** | 稿件分P总数。如果是单P视频，则为1。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

