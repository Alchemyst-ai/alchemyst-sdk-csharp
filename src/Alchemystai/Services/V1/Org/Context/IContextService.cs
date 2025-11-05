using System;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Services.V1.Org.Context;

public interface IContextService
{
    IContextService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// View organization context
    /// </summary>
    Task<ContextViewResponse> View(ContextViewParams parameters);
}
