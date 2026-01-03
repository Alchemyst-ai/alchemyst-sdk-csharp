using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context;
using Alchemystai.Services.V1.Context;

namespace Alchemystai.Services.V1;

/// <inheritdoc/>
public sealed class ContextService : IContextService
{
    /// <inheritdoc/>
    public IContextService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContextService(this._client.WithOptions(modifier));
    }

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

    /// <inheritdoc/>
    public async Task<JsonElement> Delete(
        ContextDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContextDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ContextAddResponse> Add(
        ContextAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContextAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ContextAddResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<ContextSearchResponse> Search(
        ContextSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContextSearchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ContextSearchResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
