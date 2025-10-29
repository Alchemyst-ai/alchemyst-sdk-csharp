using System.Threading.Tasks;
using AlchemystAI.Models.V1.Org.Context;

namespace AlchemystAI.Services.V1.Org.Context;

public interface IContextService
{
    /// <summary>
    /// View organization context
    /// </summary>
    Task<ContextViewResponse> View(ContextViewParams parameters);
}
