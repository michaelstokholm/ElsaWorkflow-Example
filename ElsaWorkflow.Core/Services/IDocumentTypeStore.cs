using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Models;

namespace ElsaWorkflow.Core.Services
{
    public interface IDocumentTypeStore
    {
        Task<IEnumerable<DocumentType>> ListAsync(CancellationToken cancellationToken = default);
        Task<DocumentType?> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}
