using System;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Services.V1.Context.Memory;

public interface IMemoryService
{
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint updates memory context data.
    /// </summary>
    Task Update(MemoryUpdateParams? parameters = null);

    /// <summary>
    /// Deletes memory context data based on provided parameters
    /// </summary>
    Task Delete(MemoryDeleteParams? parameters = null);

    /// <summary>
    /// This endpoint adds memory context data, fetching chat history if needed.
    /// </summary>
    Task Add(MemoryAddParams? parameters = null);
}
