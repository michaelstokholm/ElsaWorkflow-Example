using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElsaWorkflow.Core.Services
{
    public interface IFileStorage
    {
        Task WriteAsync(Stream data, string fileName, CancellationToken cancellationToken = default);
        Task<Stream> ReadAsync(string fileName, CancellationToken cancellationToken = default);
    }
}
