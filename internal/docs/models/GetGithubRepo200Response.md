# uapi-sdk-csharp.Model.GetGithubRepo200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Archived** | **bool** | 仓库是否已归档。 | [optional] 
**Collaborators** | [**List&lt;GetGithubRepo200ResponseCollaboratorsInner&gt;**](GetGithubRepo200ResponseCollaboratorsInner.md) | 协作者列表。受权限限制时可能为 null 或空数组。 | [optional] 
**CreatedAt** | **DateTime** | 创建时间（ISO 8601）。 | [optional] 
**DefaultBranch** | **string** | 默认分支名称。 | [optional] 
**DefaultBranchSha** | **string** | 默认分支最新提交的 SHA 哈希。 | [optional] 
**Description** | **string** | 仓库简介。 | [optional] 
**Disabled** | **bool** | 仓库是否被禁用。 | [optional] 
**Fork** | **bool** | 是否为 Fork 仓库。 | [optional] 
**Forks** | **int** | Fork 数。 | [optional] 
**FullName** | **string** | 仓库完整名称。 | [optional] 
**Homepage** | **string** | 仓库主页链接。 | [optional] 
**Language** | **string** | 主要语言。 | [optional] 
**Languages** | **Dictionary&lt;string, int&gt;** | 语言统计（键为语言名，值为代码字节数）。 | [optional] 
**LatestRelease** | [**GetGithubRepo200ResponseLatestRelease**](GetGithubRepo200ResponseLatestRelease.md) |  | [optional] 
**License** | **string** | 开源许可证名称。 | [optional] 
**Maintainers** | [**List&lt;GetGithubRepo200ResponseCollaboratorsInner&gt;**](GetGithubRepo200ResponseCollaboratorsInner.md) | 维护者列表（根据默认分支近期提交推断）。 | [optional] 
**OpenIssues** | **int** | 开放 Issue 数。 | [optional] 
**PrimaryBranch** | **string** | 主要分支名称（通常与默认分支一致）。 | [optional] 
**PushedAt** | **DateTime** | 最后推送时间（ISO 8601）。 | [optional] 
**Stargazers** | **int** | Star 数。 | [optional] 
**Topics** | **List&lt;string&gt;** | 话题标签列表。 | [optional] 
**UpdatedAt** | **DateTime** | 更新时间（ISO 8601）。 | [optional] 
**Visibility** | **string** | 仓库可见性，常见值为 &#x60;public&#x60; 或 &#x60;private&#x60;。 | [optional] 
**Watchers** | **int** | 关注者数量（watchers/subscribers）。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

