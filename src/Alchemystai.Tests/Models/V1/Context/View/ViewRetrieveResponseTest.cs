using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Tests.Models.V1.Context.View;

public class ViewRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "Customer asked about pricing for the Scale plan.",
                    Metadata = new()
                    {
                        FileName = "support_thread_TCK-1234.txt",
                        FileSize = 2048,
                        FileType = "text/plain",
                        GroupName = ["support", "pricing"],
                        LastModified = "2025-01-10T12:34:56.000Z",
                    },
                },
            ],
            Success = true,
        };

        List<ViewRetrieveResponseContext> expectedContexts =
        [
            new()
            {
                Content = "Customer asked about pricing for the Scale plan.",
                Metadata = new()
                {
                    FileName = "support_thread_TCK-1234.txt",
                    FileSize = 2048,
                    FileType = "text/plain",
                    GroupName = ["support", "pricing"],
                    LastModified = "2025-01-10T12:34:56.000Z",
                },
            },
        ];
        bool expectedSuccess = true;

        Assert.Equal(expectedContexts.Count, model.Contexts.Count);
        for (int i = 0; i < expectedContexts.Count; i++)
        {
            Assert.Equal(expectedContexts[i], model.Contexts[i]);
        }
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "Customer asked about pricing for the Scale plan.",
                    Metadata = new()
                    {
                        FileName = "support_thread_TCK-1234.txt",
                        FileSize = 2048,
                        FileType = "text/plain",
                        GroupName = ["support", "pricing"],
                        LastModified = "2025-01-10T12:34:56.000Z",
                    },
                },
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "Customer asked about pricing for the Scale plan.",
                    Metadata = new()
                    {
                        FileName = "support_thread_TCK-1234.txt",
                        FileSize = 2048,
                        FileType = "text/plain",
                        GroupName = ["support", "pricing"],
                        LastModified = "2025-01-10T12:34:56.000Z",
                    },
                },
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        List<ViewRetrieveResponseContext> expectedContexts =
        [
            new()
            {
                Content = "Customer asked about pricing for the Scale plan.",
                Metadata = new()
                {
                    FileName = "support_thread_TCK-1234.txt",
                    FileSize = 2048,
                    FileType = "text/plain",
                    GroupName = ["support", "pricing"],
                    LastModified = "2025-01-10T12:34:56.000Z",
                },
            },
        ];
        bool expectedSuccess = true;

        Assert.Equal(expectedContexts.Count, deserialized.Contexts.Count);
        for (int i = 0; i < expectedContexts.Count; i++)
        {
            Assert.Equal(expectedContexts[i], deserialized.Contexts[i]);
        }
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "Customer asked about pricing for the Scale plan.",
                    Metadata = new()
                    {
                        FileName = "support_thread_TCK-1234.txt",
                        FileSize = 2048,
                        FileType = "text/plain",
                        GroupName = ["support", "pricing"],
                        LastModified = "2025-01-10T12:34:56.000Z",
                    },
                },
            ],
            Success = true,
        };

        model.Validate();
    }
}

public class ViewRetrieveResponseContextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewRetrieveResponseContext
        {
            Content = "content",
            Metadata = new()
            {
                FileName = "fileName",
                FileSize = 0,
                FileType = "fileType",
                GroupName = ["string"],
                LastModified = "lastModified",
            },
        };

        string expectedContent = "content";
        Metadata expectedMetadata = new()
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedMetadata, model.Metadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewRetrieveResponseContext
        {
            Content = "content",
            Metadata = new()
            {
                FileName = "fileName",
                FileSize = 0,
                FileType = "fileType",
                GroupName = ["string"],
                LastModified = "lastModified",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewRetrieveResponseContext>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewRetrieveResponseContext
        {
            Content = "content",
            Metadata = new()
            {
                FileName = "fileName",
                FileSize = 0,
                FileType = "fileType",
                GroupName = ["string"],
                LastModified = "lastModified",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewRetrieveResponseContext>(element);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        Metadata expectedMetadata = new()
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewRetrieveResponseContext
        {
            Content = "content",
            Metadata = new()
            {
                FileName = "fileName",
                FileSize = 0,
                FileType = "fileType",
                GroupName = ["string"],
                LastModified = "lastModified",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewRetrieveResponseContext { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewRetrieveResponseContext { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewRetrieveResponseContext
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Metadata = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewRetrieveResponseContext
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        string expectedFileName = "fileName";
        double expectedFileSize = 0;
        string expectedFileType = "fileType";
        List<string> expectedGroupName = ["string"];
        string expectedLastModified = "lastModified";

        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.NotNull(model.GroupName);
        Assert.Equal(expectedGroupName.Count, model.GroupName.Count);
        for (int i = 0; i < expectedGroupName.Count; i++)
        {
            Assert.Equal(expectedGroupName[i], model.GroupName[i]);
        }
        Assert.Equal(expectedLastModified, model.LastModified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Metadata>(element);
        Assert.NotNull(deserialized);

        string expectedFileName = "fileName";
        double expectedFileSize = 0;
        string expectedFileType = "fileType";
        List<string> expectedGroupName = ["string"];
        string expectedLastModified = "lastModified";

        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.NotNull(deserialized.GroupName);
        Assert.Equal(expectedGroupName.Count, deserialized.GroupName.Count);
        for (int i = 0; i < expectedGroupName.Count; i++)
        {
            Assert.Equal(expectedGroupName[i], deserialized.GroupName[i]);
        }
        Assert.Equal(expectedLastModified, deserialized.LastModified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metadata
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("fileSize"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("groupName"));
        Assert.Null(model.LastModified);
        Assert.False(model.RawData.ContainsKey("lastModified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            FileName = null,
            FileSize = null,
            FileType = null,
            GroupName = null,
            LastModified = null,
        };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("fileSize"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("groupName"));
        Assert.Null(model.LastModified);
        Assert.False(model.RawData.ContainsKey("lastModified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            FileName = null,
            FileSize = null,
            FileType = null,
            GroupName = null,
            LastModified = null,
        };

        model.Validate();
    }
}
