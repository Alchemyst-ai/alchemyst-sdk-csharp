using System.Threading.Tasks;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Services.V1.Org.Context;

public interface IContextService
{
    /// <summary>
    /// View organization context
    /// </summary>
    Task<ContextViewResponse> View(ContextViewParams parameters);
}
