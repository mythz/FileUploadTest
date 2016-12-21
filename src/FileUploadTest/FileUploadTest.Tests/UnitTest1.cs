using System.IO;
using NUnit.Framework;
using ServiceStack;
using FileUploadTest.ServiceModel;
using UploadFile = FileUploadTest.ServiceModel.UploadFile;

namespace FileUploadTest.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private const string BaseUrl = "http://localhost:61557/";

        [Test]
        public void Can_upload_file()
        {
            var client = new JsonServiceClient(BaseUrl);

            var fileInfo = new FileInfo("~/App_Data/file.json".MapProjectPath());

            var response = client.PostFile<UploadFileResponse>(
                "/UploadFile",
                fileToUpload: fileInfo,
                mimeType: "application/json");

            Assert.That(response.Name, Is.EqualTo("file"));
            Assert.That(response.FileName, Is.EqualTo("file.json"));
            Assert.That(response.ContentLength, Is.EqualTo(fileInfo.Length));
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            Assert.That(response.Contents, Is.EqualTo(fileInfo.ReadAllText()));
            Assert.That(response.File, Is.Null);
        }

        [Test]
        public void Can_upload_file_with_Request()
        {
            var client = new JsonServiceClient(BaseUrl);

            var fileInfo = new FileInfo("~/App_Data/file.json".MapProjectPath());

            var response = client.PostFileWithRequest<UploadFileResponse>(
                "/UploadFile",
                fileToUpload: fileInfo,
                request: new UploadFile { File = "Request DTO Property" },
                fieldName: "file");

            Assert.That(response.Name, Is.EqualTo("file"));
            Assert.That(response.FileName, Is.EqualTo("file.json"));
            Assert.That(response.ContentLength, Is.EqualTo(fileInfo.Length));
            Assert.That(response.Contents, Is.EqualTo(fileInfo.ReadAllText()));
            Assert.That(response.File, Is.EqualTo("Request DTO Property"));
        }
    }
}
