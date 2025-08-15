namespace NewsPortal.Domain.Entities;

public class NewsArticle
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string Content { get; set; } = default!;
    public bool IsPublished { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    // نگهداری آیدی نویسنده (کاربر Identity)
    public string AuthorId { get; set; } = default!;
}
