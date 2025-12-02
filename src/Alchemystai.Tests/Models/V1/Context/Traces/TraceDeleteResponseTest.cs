using System.Text.Json;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Tests.Models.V1.Context.Traces;

public class TraceDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedTrace = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedTrace, model.Trace));
    }
}
