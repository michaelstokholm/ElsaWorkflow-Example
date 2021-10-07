using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ElsaWorkflow.Persistence.HostedServices
{
    public class RunMigrations : IHostedService
    {
        private readonly IDbContextFactory<DocumentDbContext> _dbContextFactory;

        public RunMigrations(IDbContextFactory<DocumentDbContext> dbContextFactoryFactory)
        {
            _dbContextFactory = dbContextFactoryFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            await dbContext.Database.MigrateAsync(cancellationToken);
            await dbContext.DisposeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
