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
    public class EFCoreDocumentStore : IDocumentStore
    {
        private readonly IDbContextFactory<DocumentDbContext> _dbContextFactory;

        public EFCoreDocumentStore(IDbContextFactory<DocumentDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task SaveAsync(Document entity, CancellationToken cancellationToken = default)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var existingDocument = await dbContext.Documents.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);

            if (existingDocument == null)
                await dbContext.Documents.AddAsync(entity, cancellationToken);
            else
                dbContext.Entry(existingDocument).CurrentValues.SetValues(entity);

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Document?> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Documents.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
