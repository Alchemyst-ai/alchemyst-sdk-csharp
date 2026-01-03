using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

public class ContextDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContextDeleteParams
        {
            OrganizationID = "org_01HXYZABC",
            Source = "support-inbox",
            ByDoc = true,
            ByID = false,
            UserID = "user_id",
        };

        string expectedOrganizationID = "org_01HXYZABC";
        string expectedSource = "support-inbox";
        bool expectedByDoc = true;
        bool expectedByID = false;
        string expectedUserID = "user_id";

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedSource, parameters.Source);
        Assert.Equal(expectedByDoc, parameters.ByDoc);
        Assert.Equal(expectedByID, parameters.ByID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContextDeleteParams
        {
            OrganizationID = "org_01HXYZABC",
            Source = "support-inbox",
        };

        Assert.Null(parameters.ByDoc);
        Assert.False(parameters.RawBodyData.ContainsKey("by_doc"));
        Assert.Null(parameters.ByID);
        Assert.False(parameters.RawBodyData.ContainsKey("by_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ContextDeleteParams
        {
            OrganizationID = "org_01HXYZABC",
            Source = "support-inbox",

            ByDoc = null,
            ByID = null,
            UserID = null,
        };

        Assert.Null(parameters.ByDoc);
        Assert.False(parameters.RawBodyData.ContainsKey("by_doc"));
        Assert.Null(parameters.ByID);
        Assert.False(parameters.RawBodyData.ContainsKey("by_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }
}
