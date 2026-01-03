using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Services.V1.Context;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMemoryService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint updates memory context data.
    /// </summary>
    Task<MemoryUpdateResponse> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes memory context data based on provided parameters.
    /// </summary>
    Task Delete(MemoryDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint adds memory context data, fetching chat history if needed.
    /// </summary>
    Task<MemoryAddResponse> Add(
        MemoryAddParams parameters,
        CancellationToken cancellationToken = default
    );
}
