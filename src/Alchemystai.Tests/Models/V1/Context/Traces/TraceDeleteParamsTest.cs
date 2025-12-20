using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Tests.Models.V1.Context.Traces;

public class TraceDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TraceDeleteParams { TraceID = "traceId" };

        string expectedTraceID = "traceId";

        Assert.Equal(expectedTraceID, parameters.TraceID);
    }
}
