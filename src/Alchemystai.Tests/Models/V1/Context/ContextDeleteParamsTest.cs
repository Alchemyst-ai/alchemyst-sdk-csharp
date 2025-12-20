using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

public class ContextDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContextDeleteParams
        {
            ByDoc = true,
            ByID = false,
            OrganizationID = "organization_id",
            Source = "support-inbox",
            UserID = "user_id",
        };

        bool expectedByDoc = true;
        bool expectedByID = false;
        string expectedOrganizationID = "organization_id";
        string expectedSource = "support-inbox";
        string expectedUserID = "user_id";

        Assert.Equal(expectedByDoc, parameters.ByDoc);
        Assert.Equal(expectedByID, parameters.ByID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedSource, parameters.Source);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContextDeleteParams
        {
            ByDoc = true,
            ByID = false,
            OrganizationID = "organization_id",
            UserID = "user_id",
        };

        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContextDeleteParams
        {
            ByDoc = true,
            ByID = false,
            OrganizationID = "organization_id",
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            Source = null,
        };

        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContextDeleteParams { Source = "support-inbox" };

        Assert.Null(parameters.ByDoc);
        Assert.False(parameters.RawBodyData.ContainsKey("by_doc"));
        Assert.Null(parameters.ByID);
        Assert.False(parameters.RawBodyData.ContainsKey("by_id"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ContextDeleteParams
        {
            Source = "support-inbox",

            ByDoc = null,
            ByID = null,
            OrganizationID = null,
            UserID = null,
        };

        Assert.Null(parameters.ByDoc);
        Assert.False(parameters.RawBodyData.ContainsKey("by_doc"));
        Assert.Null(parameters.ByID);
        Assert.False(parameters.RawBodyData.ContainsKey("by_id"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }
}
