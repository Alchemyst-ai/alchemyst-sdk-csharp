using System.Collections.Generic;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Tests.Models.V1.Org.Context;

public class ContextViewParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContextViewParams { UserIDs = ["user_123", "user_456"] };

        List<string> expectedUserIDs = ["user_123", "user_456"];

        Assert.Equal(expectedUserIDs.Count, parameters.UserIDs.Count);
        for (int i = 0; i < expectedUserIDs.Count; i++)
        {
            Assert.Equal(expectedUserIDs[i], parameters.UserIDs[i]);
        }
    }
}
