using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Net;
using Storage.Net.Blobs;

namespace ElsaWorkflow.Core.Options
{
    public class DocumentStorageOptions
    {
        public Func<IBlobStorage> BlobStorageFactory { get; set; } = StorageFactory.Blobs.InMemory;
    }
}
