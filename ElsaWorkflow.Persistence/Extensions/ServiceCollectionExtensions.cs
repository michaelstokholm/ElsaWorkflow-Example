using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Services;
using ElsaWorkflow.Persistence.HostedServices;
using ElsaWorkflow.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElsaWorkflow.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainPersistence(this IServiceCollection services, string connectionString)
        {
            var migrationsAssemblyName = typeof(SqliteDocumentDbContextFactory).Assembly.GetName().Name;

            return services
                .AddPooledDbContextFactory<DocumentDbContext>(x => x.UseSqlite(connectionString, db => db.MigrationsAssembly(migrationsAssemblyName)))
                .AddSingleton<IDocumentStore, EFCoreDocumentStore>()
                .AddSingleton<IDocumentTypeStore, EFCoreDocumentTypeStore>()
                .AddHostedService<RunMigrations>();
        }
    }
}
