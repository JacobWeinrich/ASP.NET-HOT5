using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_HOT3.Models;
using MVC_HOT3.Models.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TechStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TechShopCS")));

builder.Services.AddRouting(options => { options.LowercaseUrls = true; options.AppendTrailingSlash = true; });

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
})
    .AddEntityFrameworkStores<TechStoreContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await IdentityConfig.CreateAdminUserAsync(scope.ServiceProvider);
}

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}/{slug?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
