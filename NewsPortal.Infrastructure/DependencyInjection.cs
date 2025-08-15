using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.Application.Contracts;
using NewsPortal.Domain.Abstractions;
using NewsPortal.Infrastructure.Identity;
using NewsPortal.Infrastructure.Persistence;
using NewsPortal.Infrastructure.Services;

namespace NewsPortal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("DefaultConnection")
                 ?? "Server=(localdb)\\MSSQLLocalDB;Database=NewsPortalDb;Trusted_Connection=True;MultipleActiveResultSets=true;";

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));

        services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
        {
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<INewsService, NewsService>();

        return services;
    }

    public static async Task SeedIdentityAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roles = ["Admin", "User"];
        foreach (var r in roles)
            if (!await roleMgr.RoleExistsAsync(r))
                await roleMgr.CreateAsync(new IdentityRole(r));

        // ادمین پیش‌فرض
        var adminEmail = "admin@news.local";
        var adminUser = await userMgr.FindByEmailAsync(adminEmail);
        if (adminUser is null)
        {
            adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = adminEmail,
                EmailConfirmed = true
            };
            await userMgr.CreateAsync(adminUser, "Admin@123");
            await userMgr.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
