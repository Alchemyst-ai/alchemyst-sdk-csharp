using System;
using AlchemystAI;

namespace AlchemystAI.Tests;

public class TestBase
{
    protected IAlchemystAIClient client;

    public TestBase()
    {
        client = new AlchemystAIClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
