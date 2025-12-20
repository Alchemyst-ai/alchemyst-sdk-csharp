using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Tests.Models.V1.Context.View;

public class ViewRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ViewRetrieveParams { FileName = "file_name", MagicKey = "magic_key" };

        string expectedFileName = "file_name";
        string expectedMagicKey = "magic_key";

        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedMagicKey, parameters.MagicKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ViewRetrieveParams { };

        Assert.Null(parameters.FileName);
        Assert.False(parameters.RawQueryData.ContainsKey("file_name"));
        Assert.Null(parameters.MagicKey);
        Assert.False(parameters.RawQueryData.ContainsKey("magic_key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ViewRetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            FileName = null,
            MagicKey = null,
        };

        Assert.Null(parameters.FileName);
        Assert.False(parameters.RawQueryData.ContainsKey("file_name"));
        Assert.Null(parameters.MagicKey);
        Assert.False(parameters.RawQueryData.ContainsKey("magic_key"));
    }
}
