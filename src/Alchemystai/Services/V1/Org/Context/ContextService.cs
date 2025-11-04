using System.Net.Http;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Services.V1.Org.Context;

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
        var deserializedResponse = await response
            .Deserialize<ContextViewResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
