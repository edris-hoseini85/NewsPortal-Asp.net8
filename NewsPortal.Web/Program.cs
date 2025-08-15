using Microsoft.AspNetCore.Authorization;
using NewsPortal.Infrastructure;
using NewsPortal.Infrastructure.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// لایه‌ی Infrastructure (DbContext + Identity + Services)
builder.Services.AddInfrastructure(builder.Configuration);

// Razor Pages + Policy
builder.Services.AddRazorPages(opts =>
{
    // ناحیه ادمین نیاز به نقش Admin دارد
    opts.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminOnly");

});


// Policy
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// seeding نقش‌ها و ادمین
await app.Services.SeedIdentityAsync();
// ...
await app.Services.SeedIdentityAsync();
await app.Services.SeedCategoriesAsync();


app.Run();
