# Alchemyst AI C# API Library

> [!NOTE]
> The Alchemyst AI C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/Alchemyst-ai/alchemyst-sdk-csharp/issues/new).

The Alchemyst AI C# SDK provides convenient access to the [Alchemyst AI REST API](https://docs.getalchemystai.com) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.getalchemystai.com](https://docs.getalchemystai.com).

## Installation

```bash
git clone git@github.com:Alchemyst-ai/alchemyst-sdk-csharp.git
dotnet add reference alchemyst-sdk-csharp/src/Alchemystai
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Alchemystai;
using Alchemystai.Models.V1.Context;

AlchemystAIClient client = new();

ContextAddParams parameters = new()
{
    ContextType = ContextType.Resource,
    Documents =
    [
        new() { Content = "The content of the document" }
    ],
    Metadata = new()
    {
        FileName = "notes.txt",
        FileType = "text/plain",
        LastModified = "2025-10-01T18:42:40.419Z",
        FileSize = 1024,
    },
    Scope = Scope.Internal,
    Source = "platform.api.context.add",
};

var response = await client.V1.Context.Add(parameters);

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Alchemystai;

// Configured using the ALCHEMYST_AI_API_KEY and ALCHEMYST_AI_BASE_URL environment variables
AlchemystAIClient client = new();
```

Or manually:

```csharp
using Alchemystai;

AlchemystAIClient client = new() { APIKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable    | Required | Default value                                   |
| --------- | ----------------------- | -------- | ----------------------------------------------- |
| `APIKey`  | `ALCHEMYST_AI_API_KEY`  | false    | -                                               |
| `BaseUrl` | `ALCHEMYST_AI_BASE_URL` | true     | `"https://platform-backend.getalchemystai.com"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = new("https://example.com"),
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .V1.Context.Add(parameters);

Console.WriteLine(response);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Alchemyst AI API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.V1.Context.Add` should be called with an instance of `ContextAddParams`, and it will return an instance of `Task<JsonElement>`.

## Error handling

The SDK throws custom unchecked exception types:

- `AlchemystAIApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                  |
| ------ | ------------------------------------------ |
| 400    | `AlchemystAIBadRequestException`           |
| 401    | `AlchemystAIUnauthorizedException`         |
| 403    | `AlchemystAIForbiddenException`            |
| 404    | `AlchemystAINotFoundException`             |
| 422    | `AlchemystAIUnprocessableEntityException`  |
| 429    | `AlchemystAIRateLimitException`            |
| 5xx    | `AlchemystAI5xxException`                  |
| others | `AlchemystAIUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `AlchemystAI4xxException`.

false

- `AlchemystAIIOException`: I/O networking errors.

- `AlchemystAIInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `AlchemystAIException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Alchemystai;

AlchemystAIClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .V1.Context.Add(parameters);

Console.WriteLine(response);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Alchemystai;

AlchemystAIClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .V1.Context.Add(parameters);

Console.WriteLine(response);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `AlchemystAIInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var response = client.V1.Context.Search(parameters);
response.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Alchemystai;

AlchemystAIClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .V1.Context.Search(parameters);

Console.WriteLine(response);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/Alchemyst-ai/alchemyst-sdk-csharp/issues) with questions, bugs, or suggestions.
