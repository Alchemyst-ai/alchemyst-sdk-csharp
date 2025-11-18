using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Services;

namespace Alchemystai;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAlchemystAIClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    string? APIKey { get; init; }

    IAlchemystAIClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
