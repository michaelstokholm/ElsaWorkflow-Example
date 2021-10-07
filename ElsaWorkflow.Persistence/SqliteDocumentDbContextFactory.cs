using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ElsaWorkflow.Persistence
{
    public class SqliteDocumentDbContextFactory : IDesignTimeDbContextFactory<DocumentDbContext>
    {
        public DocumentDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DocumentDbContext>();
            var connectionString = "Data Source=elsa.db;Cache=Shared";

            builder.UseSqlite(connectionString);

            return new DocumentDbContext(builder.Options);
        }
    }
}
