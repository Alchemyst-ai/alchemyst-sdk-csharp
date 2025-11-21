using System;
using System.Net.Http;

namespace Alchemystai.Core;

public struct ClientOptions()
{
    public static readonly int DefaultMaxRetries = 2;

    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("ALCHEMYST_AI_BASE_URL")
                ?? "https://platform-backend.getalchemystai.com"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    public bool ResponseValidation { get; set; } = false;

    public int? MaxRetries { get; set; }

    public TimeSpan? Timeout { get; set; }

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("ALCHEMYST_AI_API_KEY"));
    public string? APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }
}
