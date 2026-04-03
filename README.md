# uapi-sdk-csharp

![Banner](https://raw.githubusercontent.com/AxT-Team/uapi-sdk-csharp/main/banner.png)

[![.NET](https://img.shields.io/badge/.NET-8+-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Docs](https://img.shields.io/badge/Docs-uapis.cn-2EAE5D?style=flat-square)](https://uapis.cn/)

> [!NOTE]
> 所有接口的 C# 示例都可以在 [UApi](https://uapis.cn/docs/introduction) 的接口文档页面，向下滚动至 **快速启动** 区块后直接复制。

## 快速开始

```bash
dotnet add package uapi-sdk-csharp
```

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uapi;

var client = new Client("https://uapis.cn", "YOUR_API_KEY");

try
{
    var result = await client.Misc.getMiscHotboardAsync(new Dictionary<string, object?>
        {
            ["type"] = "weibo"
        });
    Console.WriteLine($"Response: {result}");
}
catch (UapiError ex)
{
    Console.Error.WriteLine($"API call failed: {ex.Message}");
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Transport error: {ex.Message}");
}
```

这个接口默认只要传 `type` 就可以拿当前热榜。`time`、`keyword`、`time_start`、`time_end`、`limit`、`sources` 都是按场景再传的可选参数。

## 特性

现在你不再需要反反复复的查阅文档了。

只需在 IDE 中键入 `client.`，所有核心模块——如 `Social`、`Game`、`Image`——即刻同步展现。进一步输入即可直接定位到 `getSocialQqUserinfoAsync` 这样的具体方法，其名称与文档的 `operationId` 严格保持一致，确保了开发过程的直观与高效。

所有方法签名只接受真实且必需的参数。当你在构建请求时，IDE 会即时提示 `qq`、`username` 等键名，这彻底杜绝了在 `Dictionary<string, object?>` 中因键名拼写错误而导致的运行时错误。

针对 401、404、429 等标准 HTTP 响应，SDK 已将其统一映射为具名的异常类型。这些异常均附带 `Code`、`Status`、`Details` 等关键上下文信息，确保你在日志中能第一时间准确、快速地诊断问题。

`Client` 基于 `HttpClient`，构造函数会设置 BaseAddress 并自动追加 `Authorization` 头。当前版本还没有开放自定义 `HttpClient` 注入；如果你需要代理、超时或重试策略，建议在项目里再封装一层，或者按需扩展源码。

如果你需要查看字段细节或内部逻辑，仓库中的 `./internal` 目录同步保留了由 `openapi-generator` 生成的完整结构体，随时可供参考。

## 响应元信息

每次请求完成后，SDK 会自动把响应 Header 解析成结构化的 `ResponseMeta`，你不用自己拆原始字符串。

成功时可以通过 `client.LastResponseMeta` 读取，失败时可以通过 `e.Meta` 读取，两条路径拿到的是同一套字段。

```csharp
using System;
using System.Collections.Generic;
using uapi;

var client = new Client("https://uapis.cn", "YOUR_API_KEY");

// 成功路径
await client.Social.getSocialQqUserinfoAsync(
    new Dictionary<string, object?> { ["qq"] = "10001" }
);
var meta = client.LastResponseMeta;
if (meta != null) {
    Console.WriteLine($"这次请求原价: {meta.CreditsRequested ?? 0} 积分");
    Console.WriteLine($"这次实际扣费: {meta.CreditsCharged ?? 0} 积分");
    Console.WriteLine($"特殊计价: {meta.CreditsPricing ?? "原价"}");
    Console.WriteLine($"余额剩余: {meta.BalanceRemainingCents ?? 0} 分");
    Console.WriteLine($"资源包剩余: {meta.QuotaRemainingCredits ?? 0} 积分");
    Console.WriteLine($"当前有效额度桶: {meta.ActiveQuotaBuckets ?? 0}");
    Console.WriteLine($"额度用空即停: {meta.StopOnEmpty ?? false}");
    Console.WriteLine($"Key QPS: {meta.BillingKeyRateRemaining ?? 0} / {meta.BillingKeyRateLimit ?? 0} {meta.BillingKeyRateUnit ?? "req"}");
    Console.WriteLine($"Request ID: {meta.RequestId}");
}

// 失败路径
try {
    await client.Social.getSocialQqUserinfoAsync(
        new Dictionary<string, object?> { ["qq"] = "10001" }
    );
} catch (UapiError e) {
    if (e.Meta != null) {
        Console.WriteLine($"Retry-After 秒数: {e.Meta.RetryAfterSeconds}");
        Console.WriteLine($"Retry-After 原始值: {e.Meta.RetryAfterRaw ?? "-"}");
        Console.WriteLine($"访客 QPS: {e.Meta.VisitorRateRemaining ?? 0} / {e.Meta.VisitorRateLimit ?? 0}");
        Console.WriteLine($"Request ID: {e.Meta.RequestId}");
    }
}
```

常用字段一览：

| 字段 | 说明 |
|------|------|
| `CreditsRequested` | 这次请求原本要扣多少积分，也就是请求价 |
| `CreditsCharged` | 这次请求实际扣了多少积分 |
| `CreditsPricing` | 特殊计价原因，例如缓存半价 `cache-hit-half-price` |
| `BalanceRemainingCents` | 账户余额剩余（分） |
| `QuotaRemainingCredits` | 资源包剩余积分 |
| `ActiveQuotaBuckets` | 当前还有多少个有效额度桶参与计费 |
| `StopOnEmpty` | 额度耗尽后是否直接停止服务 |
| `RetryAfterSeconds` / `RetryAfterRaw` | 限流后的等待时长；当服务端返回 HTTP 时间字符串时看 `RetryAfterRaw` |
| `RequestId` | 请求唯一 ID，排障时使用 |
| `BillingKeyRateLimit` / `BillingKeyRateRemaining` | Billing Key 当前 QPS 规则的上限与剩余 |
| `BillingIPRateLimit` / `BillingIPRateRemaining` | Billing Key 单 IP 当前 QPS 规则的上限与剩余 |
| `VisitorRateLimit` / `VisitorRateRemaining` | 访客当前 QPS 规则的上限与剩余 |
| `RateLimitPolicies` / `RateLimits` | 完整结构化限流策略数据 |

## 错误模型概览

| HTTP 状态码 | SDK 错误类型                                  | 附加信息                                                                          |
|-------------|----------------------------------------------|------------------------------------------------------------------------------------|
| 401/403     | `UnauthorizedError`                          | `code`、`status`                                                                   |
| 404         | `NotFoundError` / `NoMatchError`             | `code`、`status`                                                                   |
| 400         | `InvalidParameterError` / `InvalidParamsError` | `code`、`status`、`details`                                                        |
| 429         | `ServiceBusyError`                           | `code`、`status`、`retry_after_seconds`                                            |
| 5xx         | `InternalServerErrorError` / `ApiErrorError` | `code`、`status`、`details`                                                        |
| 其他 4xx    | `UapiError`                                  | `code`、`status`、`details`                                                        |

## 其他 SDK

| 语言        | 仓库地址                                                     |
|-------------|--------------------------------------------------------------|
| Go          | https://github.com/AxT-Team/uapi-sdk-go                      |
| Python      | https://github.com/AxT-Team/uapi-sdk-python                  |
| TypeScript| https://github.com/AxT-Team/uapi-sdk-typescript           |
| Browser (TypeScript/JavaScript)| https://github.com/AxT-Team/uapi-browser-sdk        |
| Java        | https://github.com/AxT-Team/uapi-sdk-java                    |
| PHP         | https://github.com/AxT-Team/uapi-sdk-php                     |
| C#（当前）          | https://github.com/AxT-Team/uapi-sdk-csharp                  |
| C++         | https://github.com/AxT-Team/uapi-sdk-cpp                     |
| Rust        | https://github.com/AxT-Team/uapi-sdk-rust                    |

## 文档

访问 [UApi文档首页](https://uapis.cn/docs/introduction) 并选择任意接口，向下滚动到 **快速启动** 区块即可看到最新的 C# 示例代码。


