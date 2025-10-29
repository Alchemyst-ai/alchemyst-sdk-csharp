using System.Threading.Tasks;
using AlchemystAISDK.Models.V1.Org.Context;

namespace AlchemystAISDK.Services.V1.Org.Context;

public interface IContextService
{
    /// <summary>
    /// View organization context
    /// </summary>
    Task<ContextViewResponse> View(ContextViewParams parameters);
}
