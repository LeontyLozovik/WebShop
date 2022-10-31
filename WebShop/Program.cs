using AutoMapper;
using Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebShop;
using WebShop.Extensions;
using WebShop.Filters;
using WebShop.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.AddDataBase();
builder.AddIdentity();
builder.ConfigureRepositoryManager();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddMemoryCache();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddScoped<ValidateId>();
builder.Services.AddScoped<ValidateModel>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    IdentityConfiguration.Init(scope.ServiceProvider);
}

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

app.UseMiddleware<RealeProductAndShopDeleteMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.Run();
