using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Infrastructure.Identity;

namespace NewsPortal.Web.Pages.Account;

public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    public LoginModel(SignInManager<ApplicationUser> signInManager) => _signInManager = signInManager;

    [BindProperty] public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required] public string UserName { get; set; } = "";
        [Required, DataType(DataType.Password)] public string Password { get; set; } = "";
        public bool RememberMe { get; set; }
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        if (!ModelState.IsValid) return Page();
        var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, false);
        if (result.Succeeded) return LocalRedirect(returnUrl ?? "/");
        ModelState.AddModelError(string.Empty, "ورود نامعتبر است.");
        return Page();
    }
}
