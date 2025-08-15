using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Application.Contracts;
using NewsPortal.Application.DTOs;
using NewsPortal.Infrastructure.Identity;
using NewsPortal.Infrastructure.Persistence;

namespace NewsPortal.Web.Areas.Admin.Pages.News;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly INewsService _news;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppDbContext _ctx;

    public CreateModel(INewsService news, UserManager<ApplicationUser> userManager, AppDbContext ctx)
    {
        _news = news;
        _userManager = userManager;
        _ctx = ctx;
    }

    [BindProperty] public InputModel Input { get; set; } = new();
    public List<SelectItem> Categories { get; set; } = new();

    public class SelectItem { public int Id { get; set; } public string Name { get; set; } = ""; }

    public class InputModel
    {
        [Required, MaxLength(180)] public string Title { get; set; } = "";
        [Required, MaxLength(200)] public string Slug { get; set; } = "";
        [Required, MaxLength(500)] public string Summary { get; set; } = "";
        [Required] public string Content { get; set; } = "";
        [Required] public int CategoryId { get; set; }
        public bool IsPublished { get; set; }
    }

    public async Task OnGetAsync()
    {
        Categories = await _ctx.Categories.Select(c => new SelectItem { Id = c.Id, Name = c.Name }).ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine(">>> OnPostAsync called");
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        var userId = _userManager.GetUserId(User)!;
        await _news.CreateAsync(new NewsCreateDto(Input.Title, Input.Slug, Input.Summary, Input.Content, Input.CategoryId, Input.IsPublished), userId);
        return RedirectToPage("Index");
    }
}
