using System.Collections.Generic;
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
}
