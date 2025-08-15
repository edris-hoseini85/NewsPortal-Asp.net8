using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.Domain.Entities;
using NewsPortal.Infrastructure.Persistence;

namespace NewsPortal.Infrastructure.Seed;

public static class CategorySeeder
{
    public static async Task SeedCategoriesAsync(this IServiceProvider sp)
    {
        using var scope = sp.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (!await ctx.Categories.AnyAsync())
        {
            ctx.Categories.AddRange(
                new Category { Name = "سیاسی", Slug = "politics" },
                new Category { Name = "اقتصادی", Slug = "economy" },
                new Category { Name = "ورزشی", Slug = "sports" }
            );
            await ctx.SaveChangesAsync();
        }
    }
}
