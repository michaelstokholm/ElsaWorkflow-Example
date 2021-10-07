using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Options;
using ElsaWorkflow.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Storage.Net;

namespace ElsaWorkflow.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.Configure<DocumentStorageOptions>(options => options.BlobStorageFactory = StorageFactory.Blobs.InMemory);

            return services
                .AddSingleton<ISystemClock, SystemClock>()
                .AddSingleton<IFileStorage, FileStorage>()
                .AddScoped<IDocumentService, DocumentService>();
        }
    }
}
