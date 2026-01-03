using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1.Context;

public class ViewServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var view = await this.client.V1.Context.View.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        view.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Docs_Works()
    {
        var response = await this.client.V1.Context.View.Docs(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
