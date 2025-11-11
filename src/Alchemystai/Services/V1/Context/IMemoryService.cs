using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Services.V1.Context;

public interface IMemoryService
{
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint updates memory context data.
    /// </summary>
    Task Update(
        MemoryUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes memory context data based on provided parameters
    /// </summary>
    Task Delete(
        MemoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint adds memory context data, fetching chat history if needed.
    /// </summary>
    Task Add(MemoryAddParams? parameters = null, CancellationToken cancellationToken = default);
}
