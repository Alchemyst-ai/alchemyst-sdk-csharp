using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Services.V1.Context;

public interface ITraceService
{
    ITraceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a list of traces for the authenticated user
    /// </summary>
    Task<TraceListResponse> List(
        TraceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a data trace for the authenticated user with the specified trace ID
    /// </summary>
    Task<TraceDeleteResponse> Delete(
        TraceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
