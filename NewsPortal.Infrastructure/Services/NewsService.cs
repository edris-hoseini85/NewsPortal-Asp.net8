using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Application.Contracts;
using NewsPortal.Application.DTOs;
using NewsPortal.Domain.Abstractions;
using NewsPortal.Domain.Entities;
using NewsPortal.Infrastructure.Persistence;

namespace NewsPortal.Infrastructure.Services;

public class NewsService : INewsService
{
    private readonly AppDbContext _ctx;
    private readonly IRepository<NewsArticle> _repo;
    private readonly IUnitOfWork _uow;

    public NewsService(AppDbContext ctx, IRepository<NewsArticle> repo, IUnitOfWork uow)
    {
        _ctx = ctx;
        _repo = repo;
        _uow = uow;
    }

    public async Task<int> CreateAsync(NewsCreateDto dto, string authorId)
    {
        var entity = new NewsArticle
        {
            Title = dto.Title,
            Slug = dto.Slug,
            Summary = dto.Summary,
            Content = dto.Content,
            CategoryId = dto.CategoryId,
            IsPublished = dto.IsPublished,
            PublishedAt = dto.IsPublished ? DateTimeOffset.UtcNow : null,
            AuthorId = authorId
        };
        await _repo.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null) return;
        _repo.Remove(entity);
        await _uow.SaveChangesAsync();
    }

    public async Task<NewsArticle?> GetByIdAsync(int id) =>
        await _ctx.NewsArticles.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == id);

    public async Task<NewsArticle?> GetBySlugAsync(string slug) =>
        await _ctx.NewsArticles.Include(n => n.Category).FirstOrDefaultAsync(n => n.Slug == slug && n.IsPublished);

    public async Task<List<NewsArticle>> GetLatestAsync(int take = 20) =>
        await _ctx.NewsArticles.Where(n => n.IsPublished)
            .OrderByDescending(n => n.PublishedAt)
            .Take(take)
            .Include(n => n.Category)
            .ToListAsync();

    public async Task<List<NewsArticle>> ListAsync(bool? published = null)
    {
        var q = _ctx.NewsArticles.Include(n => n.Category).AsQueryable();
        if (published.HasValue) q = q.Where(n => n.IsPublished == published.Value);
        return await q.OrderByDescending(n => n.CreatedAt).ToListAsync();
    }

    public async Task UpdateAsync(NewsUpdateDto dto)
    {
        var entity = await _repo.GetByIdAsync(dto.Id);
        if (entity is null) return;

        entity.Title = dto.Title;
        entity.Slug = dto.Slug;
        entity.Summary = dto.Summary;
        entity.Content = dto.Content;
        entity.CategoryId = dto.CategoryId;
        if (!entity.IsPublished && dto.IsPublished)
            entity.PublishedAt = DateTimeOffset.UtcNow;
        entity.IsPublished = dto.IsPublished;
        entity.UpdatedAt = DateTimeOffset.UtcNow;

        _repo.Update(entity);
        await _uow.SaveChangesAsync();
    }
}
