using System.Net.Http;
using System.Threading.Tasks;
using AlchemystAI.Core;
using AlchemystAI.Models.V1.Context.Traces;

namespace AlchemystAI.Services.V1.Context.Traces;

public sealed class TraceService : ITraceService
{
    readonly IAlchemystAIClient _client;

    public TraceService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<TraceListResponse> List(TraceListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<TraceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TraceListResponse>().ConfigureAwait(false);
    }

    public async Task<TraceDeleteResponse> Delete(TraceDeleteParams parameters)
    {
        HttpRequest<TraceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TraceDeleteResponse>().ConfigureAwait(false);
    }
}
