using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Tests.Models.V1.Context.View;

public class ViewRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Context = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        List<JsonElement> expectedContext = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedContext.Count, model.Context.Count);
        for (int i = 0; i < expectedContext.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedContext[i], model.Context[i]));
        }
    }
}
