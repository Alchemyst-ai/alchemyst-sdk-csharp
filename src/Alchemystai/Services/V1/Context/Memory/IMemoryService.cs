using System.Threading.Tasks;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Services.V1.Context.Memory;

public interface IMemoryService
{
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
