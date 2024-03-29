using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using carsharing.Models;
using Microsoft.AspNetCore.Identity;
using carsharing.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<unipicarsContext>(options =>
            options.UseNpgsql(builder.Configuration["ConnectionStrings:unipi-cars-connection"]));

builder.Services.AddDbContext<carsharingIdentityDbContext>(options =>
            options.UseNpgsql(builder.Configuration["ConnectionStrings:unipi-cars-identity-connection"]));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddEntityFrameworkStores<carsharingIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{

    options.Cookie.HttpOnly = true;
    options.LoginPath = "/signin";

});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

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

app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
