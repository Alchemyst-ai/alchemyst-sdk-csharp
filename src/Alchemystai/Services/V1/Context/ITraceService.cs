using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Services.V1.Context;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
