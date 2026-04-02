# uapi-sdk-csharp.Model.GetSocialBilibiliLiveroom200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Uid** | **decimal** | 主播的用户ID (mid)。 | [optional] 
**RoomId** | **decimal** | 直播间的真实房间号（长号）。 | [optional] 
**ShortId** | **decimal** | 直播间的短号（靓号）。如果没有设置，则为0。 | [optional] 
**Attention** | **decimal** | 主播的粉丝数（关注数量）。 | [optional] 
**Online** | **decimal** | 直播间当前的人气值（对应你文档里的 PopularValue，不代表真实在线人数）。 | [optional] 
**IsPortrait** | **bool** | 是否为竖屏直播。 | [optional] 
**LiveStatus** | **decimal** | 直播状态。0:未开播, 1:直播中, 2:轮播中。 | [optional] 
**AreaId** | **decimal** | 分区ID。 | [optional] 
**ParentAreaName** | **string** | 父分区名称。 | [optional] 
**ParentAreaId** | **decimal** | 父分区 ID。 | [optional] 
**AreaName** | **string** | 子分区名称。 | [optional] 
**Background** | **string** | 直播间背景图的URL。 | [optional] 
**Title** | **string** | 当前直播间的标题。 | [optional] 
**UserCover** | **string** | 用户设置的直播间封面URL。 | [optional] 
**Description** | **string** | 直播间公告或描述，支持换行符。 | [optional] 
**LiveTime** | **string** | 本次直播开始的时间，格式为 &#x60;YYYY-MM-DD HH:mm:ss&#x60;。如果未开播，则为空字符串。 | [optional] 
**Keyframe** | **string** | 关键帧封面图链接。 | [optional] 
**Tags** | **string** | 直播间设置的标签，以逗号分隔。 | [optional] 
**HotWords** | **List&lt;string&gt;** | 直播间热词列表，通常用于弹幕互动。 | [optional] 
**NewPendants** | [**GetSocialBilibiliLiveroom200ResponseNewPendants**](GetSocialBilibiliLiveroom200ResponseNewPendants.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

