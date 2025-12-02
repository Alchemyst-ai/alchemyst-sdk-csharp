using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class ContentModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentModel { Content = "content" };

        string expectedContent = "content";

        Assert.Equal(expectedContent, model.Content);
    }
}
