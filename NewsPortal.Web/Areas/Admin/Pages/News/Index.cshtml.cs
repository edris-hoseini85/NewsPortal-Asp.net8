using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Application.Contracts;
using NewsPortal.Domain.Entities;

namespace NewsPortal.Web.Areas.Admin.Pages.News;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly INewsService _news;
    public List<NewsArticle> Items { get; set; } = new();
    public IndexModel(INewsService news) => _news = news;

    public async Task OnGetAsync()
    {
        Items = await _news.ListAsync(null);
    }
}
