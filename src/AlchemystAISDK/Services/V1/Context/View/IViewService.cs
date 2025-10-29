using System.Text.Json;
using System.Threading.Tasks;
using AlchemystAISDK.Models.V1.Context.View;

namespace AlchemystAISDK.Services.V1.Context.View;

public interface IViewService
{
    /// <summary>
    /// Gets the context information for the authenticated user
    /// </summary>
    Task<ViewRetrieveResponse> Retrieve(ViewRetrieveParams? parameters = null);

    /// <summary>
    /// Fetches documents view for authenticated user with optional organization context
    /// </summary>
    Task<JsonElement> Docs(ViewDocsParams? parameters = null);
}
