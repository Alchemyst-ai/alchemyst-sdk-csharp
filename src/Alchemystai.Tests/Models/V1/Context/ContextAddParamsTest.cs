using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document { Content = "content" };

        string expectedContent = "content";

        Assert.Equal(expectedContent, model.Content);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Document { Content = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Document>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document { Content = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Document>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";

        Assert.Equal(expectedContent, deserialized.Content);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Document { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Document
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json);
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
