# AGENTS.md — uapi-sdk-csharp

This file tells AI coding agents how to use the **official .NET / C# SDK**
for the [uapis.cn](https://uapis.cn) public API platform.

## What this package is

Idiomatic .NET client for UAPI, targeting `net8.0`. Generated from the live
OpenAPI 3.1 spec at <https://uapis.cn/openapi.json>.

## Install

```bash
dotnet add package Uapi.Sdk
```

## Quick start

```csharp
using Uapi.Sdk;

var client = new UapiClient("https://uapis.cn");
var weather = await client.Misc.GetMiscWeatherAsync(new GetMiscWeatherRequest
{
    City = "北京"
});
Console.WriteLine(weather);
```

The client is grouped by tag (`Misc`, `Network`, `Text`, `Image`, `Social`,
`Translate`, `Search`, …). Method names match the OpenAPI `operationId`,
PascalCased and suffixed with `Async`.

## Authentication

Free-tier endpoints work with no key. Paid endpoints take a key:

```csharp
var client = new UapiClient("https://uapis.cn", apiKey: "sk_…");
```

## Errors

Methods throw `UapiApiException` on non-2xx responses. The exception
carries `Code`, `Error`, and `RequestId` properties. Surface `Error`
verbatim.

## Rate limits

Headers `X-RateLimit-Limit`, `X-RateLimit-Remaining`, `X-RateLimit-Reset`,
`Retry-After` are exposed on response headers. Honor them.

## Related repos

- MCP server: <https://github.com/AxT-Team/uapi-mcp>.
- Skills bundle: <https://github.com/AxT-Team/uapi-agent-skills>.
- Other languages: `uapi-sdk-typescript`, `uapi-sdk-python`, `uapi-sdk-go`,
  `uapi-sdk-rust`, `uapi-sdk-java`, `uapi-sdk-cpp`, `uapi-sdk-php`.
