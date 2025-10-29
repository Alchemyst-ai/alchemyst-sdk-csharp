using System.Threading.Tasks;
using AlchemystAI.Models.V1.Context.Memory;

namespace AlchemystAI.Services.V1.Context.Memory;

public interface IMemoryService
{
    /// <summary>
    /// Deletes memory context data based on provided parameters
    /// </summary>
    Task Delete(MemoryDeleteParams? parameters = null);

    /// <summary>
    /// This endpoint adds memory context data, fetching chat history if needed.
    /// </summary>
    Task Add(MemoryAddParams? parameters = null);
}
