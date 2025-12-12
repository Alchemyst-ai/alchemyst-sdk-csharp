using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1;

public class ContextServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.V1.Context.Delete(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        await this.client.V1.Context.Add(new(), TestContext.Current.CancellationToken);
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
