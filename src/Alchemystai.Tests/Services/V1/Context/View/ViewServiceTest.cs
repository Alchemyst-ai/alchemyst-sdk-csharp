using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1.Context.View;

public class ViewServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var view = await this.client.V1.Context.View.Retrieve();
        view.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Docs_Works()
    {
        await this.client.V1.Context.View.Docs();
    }
}
