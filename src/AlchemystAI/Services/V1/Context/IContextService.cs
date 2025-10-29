using System.Text.Json;
using System.Threading.Tasks;
using AlchemystAI.Models.V1.Context;
using AlchemystAI.Services.V1.Context.Memory;
using AlchemystAI.Services.V1.Context.Traces;
using AlchemystAI.Services.V1.Context.View;

namespace AlchemystAI.Services.V1.Context;

public interface IContextService
{
    ITraceService Traces { get; }

    IViewService View { get; }

    IMemoryService Memory { get; }

    /// <summary>
    /// Deletes context data based on provided parameters
    /// </summary>
    Task<JsonElement> Delete(ContextDeleteParams? parameters = null);

    /// <summary>
    /// This endpoint accepts context data and sends it to a context processor for
    /// further handling. It returns a success or error response depending on the
    /// result from the context processor.
    /// </summary>
    Task<JsonElement> Add(ContextAddParams? parameters = null);

    /// <summary>
    /// This endpoint sends a search request to the context processor to retrieve
    /// relevant context data based on the provided query.
    /// </summary>
    Task<ContextSearchResponse> Search(ContextSearchParams parameters);
}
