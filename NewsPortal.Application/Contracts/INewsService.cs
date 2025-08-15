using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPortal.Application.DTOs;
using NewsPortal.Domain.Entities;

namespace NewsPortal.Application.Contracts;

public interface INewsService
{
    Task<NewsArticle?> GetBySlugAsync(string slug);
    Task<List<NewsArticle>> GetLatestAsync(int take = 20);
    Task<int> CreateAsync(NewsCreateDto dto, string authorId);
    Task UpdateAsync(NewsUpdateDto dto);
    Task DeleteAsync(int id);
    Task<NewsArticle?> GetByIdAsync(int id);
    Task<List<NewsArticle>> ListAsync(bool? published = null);
}
