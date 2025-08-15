using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Application.Contracts;
using NewsPortal.Domain.Entities;

namespace NewsPortal.Web.Pages.News;

public class DetailsModel : PageModel
{
    private readonly INewsService _news;
    public NewsArticle? Item { get; set; }

    public DetailsModel(INewsService news) => _news = news;

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        Item = await _news.GetBySlugAsync(slug);
        if (Item is null) return NotFound();
        return Page();
    }
}
