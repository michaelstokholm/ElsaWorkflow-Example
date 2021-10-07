using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Models;

namespace ElsaWorkflow.Core.Services
{
    public interface IDocumentStore
    {
        Task SaveAsync(Document entity, CancellationToken cancellationToken = default);
        Task<Document?> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}
