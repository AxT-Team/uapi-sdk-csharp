# uapi-sdk-csharp.Model.GetGithubUser200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Activity** | [**GetGithubUser200ResponseActivity**](GetGithubUser200ResponseActivity.md) |  | [optional] 
**AvatarUrl** | **string** | 用户头像图片链接。 | [optional] 
**Bio** | **string** | 用户个人简介。 | [optional] 
**Blog** | **string** | 用户填写的网站或博客地址。 | [optional] 
**Company** | **string** | 用户填写的公司或组织信息。 | [optional] 
**CreatedAt** | **DateTime** | GitHub 账号创建时间（ISO 8601）。 | [optional] 
**Email** | **string** | 用户公开可见的邮箱地址。 | [optional] 
**Followers** | **int** | 关注该用户的人数。 | [optional] 
**Following** | **int** | 该用户正在关注的人数。 | [optional] 
**HtmlUrl** | **string** | GitHub 个人主页链接。 | [optional] 
**Location** | **string** | 用户公开展示的地理位置。 | [optional] 
**Login** | **string** | GitHub 登录名。 | [optional] 
**Name** | **string** | 用户公开显示的名称。 | [optional] 
**Organizations** | [**List&lt;GetGithubUser200ResponseOrganizationsInner&gt;**](GetGithubUser200ResponseOrganizationsInner.md) | 用户公开加入的组织列表 | [optional] 
**PinnedRepositories** | [**List&lt;GetGithubUser200ResponsePinnedRepositoriesInner&gt;**](GetGithubUser200ResponsePinnedRepositoriesInner.md) | 用户主页展示的 pinned 仓库列表（需开启 pinned&#x3D;true）。 | [optional] 
**PublicGists** | **int** | 公开 Gist 数量。 | [optional] 
**PublicRepos** | **int** | 公开仓库数量。 | [optional] 
**Repositories** | [**List&lt;GetGithubUser200ResponseRepositoriesInner&gt;**](GetGithubUser200ResponseRepositoriesInner.md) | 最近活跃的公开仓库列表（需开启 repos&#x3D;true 或传入 repos_limit）。 | [optional] 
**TwitterUsername** | **string** | 用户绑定的 X（Twitter）用户名。 | [optional] 
**Type** | **string** | 账号类型，常见值为 User 或 Organization。 | [optional] 
**UpdatedAt** | **DateTime** | 用户资料最近更新时间（ISO 8601）。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

