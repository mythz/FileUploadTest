using Funq;
using ServiceStack;
using FileUploadTest.ServiceInterface;

namespace FileUploadTest
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("FileUploadTest", typeof(MyServices).Assembly) { }

        public override void Configure(Container container)
        {

        }
    }
}