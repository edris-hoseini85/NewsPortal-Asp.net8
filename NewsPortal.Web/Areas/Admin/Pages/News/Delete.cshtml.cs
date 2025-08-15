using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Application.Contracts;

namespace NewsPortal.Web.Areas.Admin.Pages.News;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly INewsService _news;
    public DeleteModel(INewsService news) => _news = news;

    public int Id { get; set; }
    public string Title { get; set; } = "";

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var n = await _news.GetByIdAsync(id);
        if (n is null) return NotFound();
        Id = n.Id; Title = n.Title;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        await _news.DeleteAsync(id);
        return RedirectToPage("Index");
    }
}
