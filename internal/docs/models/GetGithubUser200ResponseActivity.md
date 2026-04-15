# uapi-sdk-csharp.Model.GetGithubUser200ResponseActivity
贡献活动数据（需开启 activity=true）

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Scope** | **string** | 活动统计范围，常见值为 all 或 organization。 | [optional] 
**Organization** | **string** | 按组织过滤时对应的组织登录名。 | [optional] 
**From** | **string** | 统计开始日期。 | [optional] 
**To** | **string** | 统计结束日期。 | [optional] 
**TotalContributions** | **int** | 统计范围内的总贡献数。 | [optional] 
**TotalCommitContributions** | **int** | Commit 贡献总数。 | [optional] 
**TotalIssueContributions** | **int** | Issue 贡献总数。 | [optional] 
**TotalPullRequestContributions** | **int** | Pull Request 贡献总数。 | [optional] 
**TotalPullRequestReviewContributions** | **int** | Pull Request Review 贡献总数。 | [optional] 
**ContributionCalendar** | [**GetGithubUser200ResponseActivityContributionCalendar**](GetGithubUser200ResponseActivityContributionCalendar.md) |  | [optional] 
**Timeline** | [**List&lt;GetGithubUser200ResponseActivityTimelineInner&gt;**](GetGithubUser200ResponseActivityTimelineInner.md) | 按月份聚合后的贡献时间线。 | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

