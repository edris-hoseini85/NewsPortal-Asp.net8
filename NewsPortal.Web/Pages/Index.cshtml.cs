using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Application.Contracts;
using NewsPortal.Domain.Entities;

namespace NewsPortal.Web.Pages;

public class IndexModel : PageModel
{
    private readonly INewsService _news;
    public List<NewsArticle> Latest { get; set; } = new();

    public IndexModel(INewsService news) => _news = news;

    public async Task OnGetAsync()
    {
        Latest = await _news.GetLatestAsync(10);
    }
}
