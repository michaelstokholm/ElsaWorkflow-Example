using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Models;

namespace ElsaWorkflow.Core.Services
{
    public interface IDocumentService
    {
        Task<Document> SaveDocumentAsync(string fileName, Stream data, string documentTypeId, CancellationToken cancellationToken = default);
    }
}
