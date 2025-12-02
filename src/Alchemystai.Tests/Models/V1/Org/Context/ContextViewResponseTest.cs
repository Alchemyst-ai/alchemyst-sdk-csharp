using System.Text.Json;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Tests.Models.V1.Org.Context;

public class ContextViewResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextViewResponse
        {
            Contexts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedContexts = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedContexts, model.Contexts));
    }
}
