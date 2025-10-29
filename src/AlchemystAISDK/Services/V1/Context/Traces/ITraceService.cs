using System.Threading.Tasks;
using AlchemystAISDK.Models.V1.Context.Traces;

namespace AlchemystAISDK.Services.V1.Context.Traces;

public interface ITraceService
{
    /// <summary>
    /// Retrieves a list of traces for the authenticated user
    /// </summary>
    Task<TraceListResponse> List(TraceListParams? parameters = null);

    /// <summary>
    /// Deletes a data trace for the authenticated user with the specified trace ID
    /// </summary>
    Task<TraceDeleteResponse> Delete(TraceDeleteParams parameters);
}
