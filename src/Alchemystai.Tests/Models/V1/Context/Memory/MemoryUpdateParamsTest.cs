using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content { Content1 = "content" };

        string expectedContent1 = "content";

        Assert.Equal(expectedContent1, model.Content1);
    }
}
