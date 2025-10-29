using System.Net.Http;
using System.Threading.Tasks;
using AlchemystAISDK.Core;
using AlchemystAISDK.Models.V1.Org.Context;

namespace AlchemystAISDK.Services.V1.Org.Context;

public sealed class ContextService : IContextService
{
    readonly IAlchemystAIClient _client;

    public ContextService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<ContextViewResponse> View(ContextViewParams parameters)
    {
        HttpRequest<ContextViewParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ContextViewResponse>().ConfigureAwait(false);
    }
}
