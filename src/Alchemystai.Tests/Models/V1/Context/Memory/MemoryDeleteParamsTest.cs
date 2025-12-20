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
            OrganizationID = "organization_id",
            UserID = "user_id",
        };

        string expectedMemoryID = "support-thread-TCK-1234";
        string expectedOrganizationID = "organization_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedMemoryID, parameters.MemoryID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            OrganizationID = "organization_id",
            UserID = "user_id",
        };

        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            OrganizationID = "organization_id",
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            MemoryID = null,
        };

        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryId"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryDeleteParams { MemoryID = "support-thread-TCK-1234" };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryID = "support-thread-TCK-1234",

            OrganizationID = null,
            UserID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }
}
