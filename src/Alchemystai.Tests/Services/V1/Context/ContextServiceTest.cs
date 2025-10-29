using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1.Context;

public class ContextServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var context = await this.client.V1.Context.Delete();
        _ = context;
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.V1.Context.Add();
        _ = response;
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Search_Works()
    {
        var response = await this.client.V1.Context.Search(
            new()
            {
                MinimumSimilarityThreshold = 0.5,
                Query = "search query for user preferences",
                SimilarityThreshold = 0.8,
            }
        );
        response.Validate();
    }
}
