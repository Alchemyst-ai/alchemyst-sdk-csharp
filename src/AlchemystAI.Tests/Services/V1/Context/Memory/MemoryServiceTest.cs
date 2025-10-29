using System.Threading.Tasks;

namespace AlchemystAI.Tests.Services.V1.Context.Memory;

public class MemoryServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.V1.Context.Memory.Delete();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        await this.client.V1.Context.Memory.Add();
    }
}
