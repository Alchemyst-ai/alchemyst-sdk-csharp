using System.Threading.Tasks;
using AlchemystAI.Models.V1.Context.Traces;

namespace AlchemystAI.Services.V1.Context.Traces;

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
