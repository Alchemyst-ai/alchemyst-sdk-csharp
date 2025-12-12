using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1.Context;

public class TraceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var traces = await this.client.V1.Context.Traces.List(
            new(),
            TestContext.Current.CancellationToken
        );
        traces.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var trace = await this.client.V1.Context.Traces.Delete(
            "traceId",
            new(),
            TestContext.Current.CancellationToken
        );
        trace.Validate();
    }
}
