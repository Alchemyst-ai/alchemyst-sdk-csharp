using System;
using System.Net.Http;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Services.V1;

namespace Alchemystai;

public interface IAlchemystAIClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string? APIKey { get; init; }

    IV1Service V1 { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
