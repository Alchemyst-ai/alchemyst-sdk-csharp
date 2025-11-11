using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1.Org;

public class ContextServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task View_Works()
    {
        var response = await this.client.V1.Org.Context.View(new() { UserIDs = ["string"] });
        response.Validate();
    }
}
