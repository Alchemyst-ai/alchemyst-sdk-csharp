using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context;
using Alchemystai.Services.V1.Context;

namespace Alchemystai.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IContextService
{
    IContextService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITraceService Traces { get; }

    IViewService View { get; }

    IMemoryService Memory { get; }

    /// <summary>
    /// Deletes context data based on provided parameters
    /// </summary>
    Task<JsonElement> Delete(
        ContextDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint accepts context data and sends it to a context processor for
    /// further handling. It returns a success or error response depending on the
    /// result from the context processor.
    /// </summary>
    Task<JsonElement> Add(
        ContextAddParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint sends a search request to the context processor to retrieve
    /// relevant context data based on the provided query.
    /// </summary>
    Task<ContextSearchResponse> Search(
        ContextSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
