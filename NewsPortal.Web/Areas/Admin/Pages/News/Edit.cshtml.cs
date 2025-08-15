using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Application.Contracts;
using NewsPortal.Application.DTOs;
using NewsPortal.Infrastructure.Persistence;

namespace NewsPortal.Web.Areas.Admin.Pages.News;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly INewsService _news;
    private readonly AppDbContext _ctx;

    public EditModel(INewsService news, AppDbContext ctx)
    {
        _news = news;
        _ctx = ctx;
    }

    [BindProperty] public InputModel Input { get; set; } = new();
    public List<(int Id, string Name)> Categories { get; set; } = new();

    public class InputModel
    {
        public int Id { get; set; }
        [Required, MaxLength(180)] public string Title { get; set; } = "";
        [Required, MaxLength(200)] public string Slug { get; set; } = "";
        [Required, MaxLength(500)] public string Summary { get; set; } = "";
        [Required] public string Content { get; set; } = "";
        [Required] public int CategoryId { get; set; }
        public bool IsPublished { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var n = await _news.GetByIdAsync(id);
        if (n is null) return NotFound();

        Input = new InputModel
        {
            Id = n.Id,
            Title = n.Title,
            Slug = n.Slug,
            Summary = n.Summary,
            Content = n.Content,
            CategoryId = n.CategoryId,
            IsPublished = n.IsPublished
        };

        Categories = await _ctx.Categories.Select(c => new ValueTuple<int, string>(c.Id, c.Name)).ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _ctx.Categories.Select(c => new ValueTuple<int, string>(c.Id, c.Name)).ToListAsync();
            return Page();
        }

        await _news.UpdateAsync(new NewsUpdateDto(Input.Id, Input.Title, Input.Slug, Input.Summary, Input.Content, Input.CategoryId, Input.IsPublished));
        return RedirectToPage("Index");
    }
}
