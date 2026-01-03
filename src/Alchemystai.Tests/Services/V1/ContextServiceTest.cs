using System.Threading.Tasks;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Services.V1;

public class ContextServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.V1.Context.Delete(
            new() { OrganizationID = "org_01HXYZABC", Source = "support-inbox" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.V1.Context.Add(
            new()
            {
                ContextType = ContextType.Resource,
                Documents =
                [
                    new() { Content = "Customer asked about pricing for the Scale plan." },
                ],
                Scope = Scope.Internal,
                Source = "support-inbox",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        var response = await this.client.V1.Context.Search(
            new()
            {
                MinimumSimilarityThreshold = 0.5,
                Query = "What did the customer ask about pricing for the Scale plan?",
                SimilarityThreshold = 0.8,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
