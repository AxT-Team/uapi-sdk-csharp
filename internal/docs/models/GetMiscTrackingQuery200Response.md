# uapi-sdk-csharp.Model.GetMiscTrackingQuery200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CarrierCode** | **string** | 快递公司编码 | [optional] 
**CarrierName** | **string** | 快递公司名称 | [optional] 
**CompletedAt** | **string** | 完成时间。仅已完成时返回签收或妥投对应的轨迹时间；未完成时为空字符串。 | [optional] 
**IsCompleted** | **bool** | 快递是否已完成。仅当状态识别为已签收/已妥投/已完成时为 true。 | [optional] 
**Status** | **string** | 快递状态中文名称，例如：待揽收、已揽收、运输中、派送中、已完成、异常、未知。 | [optional] 
**StatusCode** | **string** | 快递状态编码。可能值：pending、picked_up、in_transit、out_for_delivery、delivered、exception、unknown。 | [optional] 
**TrackCount** | **int** | 物流轨迹数量 | [optional] 
**TrackingNumber** | **string** | 快递单号 | [optional] 
**Tracks** | [**List&lt;GetMiscTrackingQuery200ResponseTracksInner&gt;**](GetMiscTrackingQuery200ResponseTracksInner.md) | 物流轨迹列表，按时间倒序排列 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

