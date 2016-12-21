using System;
using System.Runtime.Serialization;
using ServiceStack;

namespace FileUploadTest.ServiceModel
{
    [DataContract]
    [Route("/UploadFile", "POST")]
    public class UploadFile : IReturn<UploadFileResponse>
    {
        [DataMember]
        public string File { get; set; }
    }

    [DataContract]
    public class UploadFileResponse : IHasResponseStatus
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public long ContentLength { get; set; }

        [DataMember]
        public string ContentType { get; set; }

        [DataMember]
        public string Contents { get; set; }

        [DataMember]
        public string File { get; set; }

        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
}