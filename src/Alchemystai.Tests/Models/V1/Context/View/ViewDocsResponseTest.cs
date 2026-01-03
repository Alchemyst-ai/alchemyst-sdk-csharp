using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Tests.Models.V1.Context.View;

public class ViewDocsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewDocsResponse
        {
            Documents =
            [
                new()
                {
                    FileName = "fileName",
                    FileSize = 0,
                    FileType = "fileType",
                    GroupName = ["string"],
                    LastModified = "lastModified",
                },
            ],
        };

        List<Document> expectedDocuments =
        [
            new()
            {
                FileName = "fileName",
                FileSize = 0,
                FileType = "fileType",
                GroupName = ["string"],
                LastModified = "lastModified",
            },
        ];

        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewDocsResponse
        {
            Documents =
            [
                new()
                {
                    FileName = "fileName",
                    FileSize = 0,
                    FileType = "fileType",
                    GroupName = ["string"],
                    LastModified = "lastModified",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewDocsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewDocsResponse
        {
            Documents =
            [
                new()
                {
                    FileName = "fileName",
                    FileSize = 0,
                    FileType = "fileType",
                    GroupName = ["string"],
                    LastModified = "lastModified",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewDocsResponse>(element);
        Assert.NotNull(deserialized);

        List<Document> expectedDocuments =
        [
            new()
            {
                FileName = "fileName",
                FileSize = 0,
                FileType = "fileType",
                GroupName = ["string"],
                LastModified = "lastModified",
            },
        ];

        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewDocsResponse
        {
            Documents =
            [
                new()
                {
                    FileName = "fileName",
                    FileSize = 0,
                    FileType = "fileType",
                    GroupName = ["string"],
                    LastModified = "lastModified",
                },
            ],
        };

        model.Validate();
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document
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
        var model = new Document
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Document>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Document>(element);
        Assert.NotNull(deserialized);

        string expectedFileName = "fileName";
        double expectedFileSize = 0;
        string expectedFileType = "fileType";
        List<string> expectedGroupName = ["string"];
        string expectedLastModified = "lastModified";

        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFileType, deserialized.FileType);
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
        var model = new Document
        {
            FileName = "fileName",
            FileSize = 0,
            FileType = "fileType",
            GroupName = ["string"],
            LastModified = "lastModified",
        };

        model.Validate();
    }
}
