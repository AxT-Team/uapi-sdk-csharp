# uapi-sdk-csharp.Model.PostTextAesEncryptAdvancedRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Key** | **string** | 加密密钥（支持任意长度） | 
**Text** | **string** | 待加密的明文文本 | 
**Iv** | **string** | 自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数 | [optional] 
**Mode** | **string** | 加密模式：GCM/CBC/ECB/CTR/OFB/CFB（可选，默认GCM） | [optional] 
**OutputFormat** | **string** | 输出格式：base64（默认）或hex | [optional] 
**Padding** | **string** | 填充方式：PKCS7/ZERO/NONE（可选，默认PKCS7） | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

