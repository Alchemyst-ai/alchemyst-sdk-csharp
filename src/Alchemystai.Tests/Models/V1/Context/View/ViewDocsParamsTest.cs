using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Tests.Models.V1.Context.View;

public class ViewDocsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ViewDocsParams { MagicKey = "magic_key" };

        string expectedMagicKey = "magic_key";

        Assert.Equal(expectedMagicKey, parameters.MagicKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ViewDocsParams { };

        Assert.Null(parameters.MagicKey);
        Assert.False(parameters.RawQueryData.ContainsKey("magic_key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ViewDocsParams
        {
            // Null should be interpreted as omitted for these properties
            MagicKey = null,
        };

        Assert.Null(parameters.MagicKey);
        Assert.False(parameters.RawQueryData.ContainsKey("magic_key"));
    }
}
