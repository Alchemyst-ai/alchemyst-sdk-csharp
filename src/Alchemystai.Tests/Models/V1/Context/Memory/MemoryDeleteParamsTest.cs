using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class MemoryDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryID = "support-thread-TCK-1234",
            OrganizationID = "org_01HXYZABC",
            ByDoc = true,
            ByID = false,
            UserID = "user_id",
        };

        string expectedMemoryID = "support-thread-TCK-1234";
        string expectedOrganizationID = "org_01HXYZABC";
        bool expectedByDoc = true;
        bool expectedByID = false;
        string expectedUserID = "user_id";

        Assert.Equal(expectedMemoryID, parameters.MemoryID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedByDoc, parameters.ByDoc);
        Assert.Equal(expectedByID, parameters.ByID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryID = "support-thread-TCK-1234",
            OrganizationID = "org_01HXYZABC",
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
        var parameters = new MemoryDeleteParams
        {
            MemoryID = "support-thread-TCK-1234",
            OrganizationID = "org_01HXYZABC",

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
