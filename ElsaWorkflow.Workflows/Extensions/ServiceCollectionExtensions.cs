using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Providers.Workflows;
using Elsa.Server.Hangfire.Extensions;
using ElsaWorkflow.Workflows.Activities;
using ElsaWorkflow.Workflows.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage.Net;

namespace ElsaWorkflow.Workflows.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWorkflowServices(this IServiceCollection services, Action<DbContextOptionsBuilder> configureDb)
        {
            return services.AddElsa(configureDb)
                .AddNotificationHandlersFrom<StartDocumentWorkflows>();
        }

        private static IServiceCollection AddElsa(this IServiceCollection services, Action<DbContextOptionsBuilder> configureDb)
        {
            services
                .AddElsa(elsa => elsa

                    // Use EF Core's SQLite provider to store workflow instances and bookmarks.
                    .UseEntityFrameworkPersistence(configureDb)

                    // Ue Console activities for testing & demo purposes.
                    .AddConsoleActivities()

                    // Use Hangfire to dispatch workflows from.
                    .UseHangfireDispatchers()

                    // Configure Email activities.
                    .AddEmailActivities()

                    // Configure HTTP activities.
                    .AddHttpActivities()

                    // Add custom activities
                    .AddActivitiesFrom<GetDocument>()
                );
           

            var currentAssemblyPath = Path.GetDirectoryName(typeof(ServiceCollectionExtensions).Assembly.Location);

            services.Configure<BlobStorageWorkflowProviderOptions>(options => options.BlobStorageFactory = () => StorageFactory.Blobs.DirectoryFiles(Path.Combine(currentAssemblyPath, "Workflows")));


            return services;
        }
    }
}
