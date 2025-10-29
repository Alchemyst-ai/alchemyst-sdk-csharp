using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AlchemystAISDK.Core;
using AlchemystAISDK.Models.V1.Context;
using AlchemystAISDK.Services.V1.Context.Memory;
using AlchemystAISDK.Services.V1.Context.Traces;
using AlchemystAISDK.Services.V1.Context.View;

namespace AlchemystAISDK.Services.V1.Context;

public sealed class ContextService : IContextService
{
    readonly IAlchemystAIClient _client;

    public ContextService(IAlchemystAIClient client)
    {
        _client = client;
        _traces = new(() => new TraceService(client));
        _view = new(() => new ViewService(client));
        _memory = new(() => new MemoryService(client));
    }

    readonly Lazy<ITraceService> _traces;
    public ITraceService Traces
    {
        get { return _traces.Value; }
    }

    readonly Lazy<IViewService> _view;
    public IViewService View
    {
        get { return _view.Value; }
    }

    readonly Lazy<IMemoryService> _memory;
    public IMemoryService Memory
    {
        get { return _memory.Value; }
    }

    public async Task<JsonElement> Delete(ContextDeleteParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ContextDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }

    public async Task<JsonElement> Add(ContextAddParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ContextAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }

    public async Task<ContextSearchResponse> Search(ContextSearchParams parameters)
    {
        HttpRequest<ContextSearchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ContextSearchResponse>().ConfigureAwait(false);
    }
}
