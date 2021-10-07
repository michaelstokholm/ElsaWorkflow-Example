using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Options;
using Microsoft.Extensions.Options;
using Storage.Net.Blobs;

namespace ElsaWorkflow.Core.Services
{
    public class FileStorage : IFileStorage
    {
        private readonly IBlobStorage _blobStorage;

        public FileStorage(IOptions<DocumentStorageOptions> options) => _blobStorage = options.Value.BlobStorageFactory();

        public Task WriteAsync(Stream data, string fileName, CancellationToken cancellationToken = default) =>
            _blobStorage.WriteAsync(fileName, data, false, cancellationToken);

        public Task<Stream> ReadAsync(string fileName, CancellationToken cancellationToken = default) =>
            _blobStorage.OpenReadAsync(fileName, cancellationToken);
    }
}
