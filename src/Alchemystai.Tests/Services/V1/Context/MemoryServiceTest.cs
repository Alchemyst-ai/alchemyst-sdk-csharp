using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alchemystai.Tests.Services.V1.Context;

public class MemoryServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var memory = await this.client.V1.Context.Memory.Update(
            new()
            {
                Contents =
                [
                    new()
                    {
                        ID = "msg-1",
                        ContentValue = "Customer asked about pricing for the Scale plan.",
                        CreatedAt = "2025-01-10T12:34:56.000Z",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "messageId", JsonSerializer.SerializeToElement("bar") },
                        },
                        Role = "user",
                    },
                    new()
                    {
                        ID = "msg-2",
                        ContentValue =
                            "Updated answer about the Scale plan pricing after discounts.",
                        CreatedAt = "2025-01-10T12:36:00.000Z",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "messageId", JsonSerializer.SerializeToElement("bar") },
                        },
                        Role = "assistant",
                    },
                ],
                MemoryID = "support-thread-TCK-1234",
            },
            TestContext.Current.CancellationToken
        );
        memory.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.V1.Context.Memory.Delete(
            new() { MemoryID = "support-thread-TCK-1234", OrganizationID = "org_01HXYZABC" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.V1.Context.Memory.Add(
            new()
            {
                Contents =
                [
                    new()
                    {
                        ID = "msg-1",
                        Content = "Customer asked about pricing for the Scale plan.",
                        CreatedAt = "2025-01-10T12:34:56.000Z",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "messageId", JsonSerializer.SerializeToElement("bar") },
                        },
                        Role = "user",
                    },
                    new()
                    {
                        ID = "msg-2",
                        Content =
                            "Explained the Scale plan pricing and shared the pricing page link.",
                        CreatedAt = "2025-01-10T12:35:30.000Z",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "messageId", JsonSerializer.SerializeToElement("bar") },
                        },
                        Role = "assistant",
                    },
                ],
                MemoryID = "support-thread-TCK-1234",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
