namespace NewsPortal.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;

    public ICollection<NewsArticle> Articles { get; set; } = new List<NewsArticle>();
}
