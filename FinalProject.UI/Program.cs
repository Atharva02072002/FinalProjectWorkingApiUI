using FinalProject.Contracts;
using FinalProject.LoggerService;
using FinalProject.Repository;
using FinalProject.Repository.Configuration;
using FinalProject.Service.Contract;
using FinalProject.Services;
using FinalProject.UI.Models;
using FinalProject.UI.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//to access back end Services

builder.Services.AddHttpClient();
// Register UserConfiguration
//builder.Services.Configure<UserConfigurationDetail>(builder.Configuration.GetSection("UsersDetail"));
builder.Services.AddSingleton<UserConfigurationDetail>();

// Add MVC services
builder.Services.AddControllersWithViews();
// Razor Pages
//builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:IdentityConnection"]);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();


// Authentication configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Session configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;  // Required for GDPR compliance if applicable
});

// Register your EF Core DbContext here
//builder.Services.AddDbContext<RepositoryContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
//builder.Services.AddScoped<IServiceManager, ServiceManager>();
//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
//builder.Services.AddScoped<ILoggerManager, LoggerManager>();
//builder.Services.AddScoped<IDepartmentService, DepartmentService>();
//builder.Services.AddScoped<IRoomService, RoomService>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();  // Add other services here

// Add AutoMapper
//builder.Services.AddAutoMapper(typeof(FinalProject.Web.API.MappingProfile));

// Add Authorization configuration
builder.Services.AddAuthorization();
// To check login
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Middleware order is critical!

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();  // Strict HTTP Security
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Prevent caching of authenticated pages
//app.Use(async (context, next) =>
//{
//    await next();

//    //if (context.User.Identity?.IsAuthenticated == true)
//    //{
//    //    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
//    //    context.Response.Headers["Pragma"] = "no-cache";
//    //    context.Response.Headers["Expires"] = "0";
//    //}
//});

// Routing
app.UseRouting();

// Add session BEFORE authentication and authorization
app.UseSession();

// Authentication & Authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

// Map default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Landing1}/{id?}");

// Mapping Razor Pages
//app.MapRazorPages();
IdentitySeedData.SeedDataAsync(app);
app.Run();
