using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Data;
using GroupWebProject.Models.Interfaces;
using GroupWebProject.Models.Services;
using GroupWebProject.Models;
using System;
using GroupWebProject.Migrations;
using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using SeedData = GroupWebProject.Areas.Identity.Data.SeedData;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GroupContextConnection") ?? throw new InvalidOperationException("Connection string 'GroupContextConnection' not found.");

builder.Services.AddDbContext<GroupContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GroupContext>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential= true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAzureBlob, AzureBlobService>();
AddAuthorizationPolicies();
AddScoped();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<GroupContext>();
SeedData.SeedDatabase(context);

app.Run();

void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options => 
    {
        options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
});
}

void AddScoped()
{
    builder.Services.AddScoped<IUser, Users>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
