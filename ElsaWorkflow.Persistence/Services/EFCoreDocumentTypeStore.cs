using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Models;
using ElsaWorkflow.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace ElsaWorkflow.Persistence.Services
{
    public class EFCoreDocumentTypeStore : IDocumentTypeStore
    {
        private readonly IDbContextFactory<DocumentDbContext> _dbContextFactory;

        public EFCoreDocumentTypeStore(IDbContextFactory<DocumentDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<DocumentType>> ListAsync(CancellationToken cancellationToken = default)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.DocumentTypes.ToListAsync(cancellationToken);
        }

        public async Task<DocumentType?> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
