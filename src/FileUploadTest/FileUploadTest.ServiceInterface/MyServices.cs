using System.IO;
using ServiceStack;
using FileUploadTest.ServiceModel;
using UploadFile = FileUploadTest.ServiceModel.UploadFile;

namespace FileUploadTest.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello, {0}!".Fmt(request.Name) };
        }

        public object Post(UploadFile request)
        {
            if (this.Request.Files.Length == 0)
                throw new FileNotFoundException("UploadError", "No such file exists");

            var file = this.Request.Files[0];
            return new UploadFileResponse
            {
                Name = file.Name,
                FileName = file.FileName,
                ContentLength = file.ContentLength,
                ContentType = file.ContentType,
                Contents = new StreamReader(file.InputStream).ReadToEnd(),
                File = request.File,
            };
        }
    }
}