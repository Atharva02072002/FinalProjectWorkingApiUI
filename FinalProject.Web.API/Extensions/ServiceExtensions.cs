using FinalProject.Contracts;
using FinalProject.LoggerService;
using FinalProject.Repository;
using FinalProject.Service.Contract;
using FinalProject.Services;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Web.API.Extensions
{
    public static class ServiceExtensions
    {
        // Configure CORS to allow any origin, method, and header
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

        // Configure IIS integration options
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        // Register LoggerService for dependency injection
        // This ensures that ILoggerManager is resolved to an instance of LoggerManager
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        // Register RepositoryManager for dependency injection
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        // Register ServiceManager for dependency injection
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        // Configure SQL context with connection string from configuration
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AmbWebApiDb")));
    }
}
