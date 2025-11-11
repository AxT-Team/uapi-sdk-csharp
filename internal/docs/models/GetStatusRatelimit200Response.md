# uapi-sdk-csharp.Model.GetStatusRatelimit200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Accepts** | **int** | Total number of accepted requests | [optional] 
**InFlight** | **int** | Number of current in-flight requests | [optional] 
**LastUpdate** | **string** | Last update time of the status | [optional] 
**Limit** | **int** | Current concurrency limit | [optional] 
**Load** | **decimal** | Calculated system load (in_flight / limit) | [optional] 
**MinRtt** | **decimal** | Minimum observed RTT in milliseconds | [optional] 
**Rejects** | **int** | Total number of rejected requests | [optional] 
**Rtt** | **decimal** | Smoothed RTT in milliseconds | [optional] 
**Throttled** | **int** | Total number of throttled requests | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

