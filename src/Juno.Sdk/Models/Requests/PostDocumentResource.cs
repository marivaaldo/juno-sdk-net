using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class PostDocumentResource : IRequestResource
    {
        public string ResourceToken { get; set; }

        public string DocumentId { get; set; }

        public List<FileData> Files { get; set; }
    }

    public class PostEncryptedDocument : IRequestResource
    {
        public string ResourceToken { get; set; }

        public string DocumentId { get; set; }

        public FileData File { get; set; }

        public string PublicKey { get; set; }
    }
}
