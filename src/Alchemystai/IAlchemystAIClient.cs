using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Services.V1;

namespace Alchemystai;

public interface IAlchemystAIClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    TimeSpan Timeout { get; init; }

    string? APIKey { get; init; }

    IAlchemystAIClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
