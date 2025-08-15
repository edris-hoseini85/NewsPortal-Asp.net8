using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain.Entities;
using NewsPortal.Infrastructure.Identity;


namespace NewsPortal.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<NewsArticle> NewsArticles => Set<NewsArticle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // دسته‌بندی‌های پیش فرض
        modelBuilder.Entity<Category>().HasData(
            new Category { Id=1, Name = "سیاست", Slug = "politics" },
            new Category { Id = 2,Name = "ورزش", Slug = "sports" },
            new Category { Id =3,Name = "علم و فناوری", Slug = "technology" },
            new Category { Id = 4, Name = "فرهنگ و هنر", Slug = "culture" }
        );

        // اخبار پیش فرض
        modelBuilder.Entity<NewsArticle>().HasData(
            new NewsArticle
            {
                Id = 1,
                Title = "خبر اول سایت خبری",
                Slug = "news-1",
                Summary = "خلاصه خبر اول",
                Content = "متن کامل خبر اول",
                IsPublished = true,
                PublishedAt = DateTimeOffset.Now,
                CreatedAt = DateTimeOffset.Now,
                CategoryId = 1,
                AuthorId = "SYSTEM"
            },
            new NewsArticle
            {
                Id = 2,
                Title = "خبر دوم سایت خبری",
                Slug = "news-2",
                Summary = "خلاصه خبر دوم",
                Content = "متن کامل خبر دوم",
                IsPublished = true,
                PublishedAt = DateTimeOffset.Now,
                CreatedAt = DateTimeOffset.Now,
                CategoryId = 2,
                AuthorId = "SYSTEM"
            },
            new NewsArticle
            {
                Id = 3,
                Title = "خبر سوم سایت خبری",
                Slug = "news-3",
                Summary = "خلاصه خبر سوم",
                Content = "متن کامل خبر سوم",
                IsPublished = true,
                PublishedAt = DateTimeOffset.Now,
                CreatedAt = DateTimeOffset.Now,
                CategoryId = 3,
                AuthorId = "SYSTEM"
            },
            new NewsArticle
            {
                Id = 4,
                Title = "خبر چهارم سایت خبری",
                Slug = "news-4",
                Summary = "خلاصه خبر چهارم",
                Content = "متن کامل خبر چهارم",
                IsPublished = true,
                PublishedAt = DateTimeOffset.Now,
                CreatedAt = DateTimeOffset.Now,
                CategoryId = 4,
                AuthorId = "SYSTEM"
            }
        );
    }
}
