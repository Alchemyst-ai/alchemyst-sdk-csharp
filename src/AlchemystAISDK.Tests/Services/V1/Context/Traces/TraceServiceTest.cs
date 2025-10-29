using System.Threading.Tasks;

namespace AlchemystAISDK.Tests.Services.V1.Context.Traces;

public class TraceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var traces = await this.client.V1.Context.Traces.List();
        traces.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var trace = await this.client.V1.Context.Traces.Delete(new() { TraceID = "traceId" });
        trace.Validate();
    }
}
