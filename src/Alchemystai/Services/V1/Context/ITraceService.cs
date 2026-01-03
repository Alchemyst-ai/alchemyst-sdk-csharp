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
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITraceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns paginated traces for the authenticated user within their organization.
    /// </summary>
    Task<TraceListResponse> List(
        TraceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a data trace for the authenticated user with the specified trace ID.
    /// </summary>
    Task<TraceDeleteResponse> Delete(
        TraceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TraceDeleteParams, CancellationToken)"/>
    Task<TraceDeleteResponse> Delete(
        string traceID,
        TraceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
