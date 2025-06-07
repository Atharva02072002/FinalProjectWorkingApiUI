using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using FinalProject.Repository;

namespace FinalProject.Web.API.ContextFactory
{
    // Factory class for creating instances of RepositoryContext at design time
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        // Method to create a new instance of RepositoryContext
        public RepositoryContext CreateDbContext(string[] args)
        {
            // Build configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();

            // Configure DbContext options to use SQL Server with the connection string from configuration
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("AmbWebApiDb"),
                b => b.MigrationsAssembly("FinalProject.Web.API"));

            // Return a new instance of RepositoryContext with the configured options
            return new RepositoryContext(builder.Options);
        }
    }
}
