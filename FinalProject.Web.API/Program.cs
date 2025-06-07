using FinalProject.Contracts;
using FinalProject.LoggerService;
using FinalProject.Repository;
using FinalProject.Service.Contract;
using FinalProject.Services;
using FinalProject.Web.API;
using FinalProject.Web.API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Setup NLog for logging
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Register services and repositories for Dependency Injection (DI)
builder.Services.AddScoped<IAmbulanceRepository, AmbulanceRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>(); // Assuming you have LoggerManager implementation

// Register AutoMapper with your MappingProfile
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add controllers from the Presentation layer
builder.Services.AddControllers()
    .AddApplicationPart(typeof(FinalProject.Presentation.AssemblyReference).Assembly)
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });


// Add Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS, IIS integration, and SQL Context (assuming you have these extension methods)
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureSqlContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Use HSTS in production environment
    app.UseHsts();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable serving static files
//app.UseStaticFiles();

// Configure forwarded headers to support reverse proxy scenarios
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

// Enable CORS with the specified policy
app.UseCors("CorsPolicy");

// Enable authorization middleware
app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Run the application
app.Run();