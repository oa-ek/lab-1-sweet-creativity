﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetCreativity.Core.Context;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SweetCreativityConnection") ?? throw new InvalidOperationException("Connection string 'SweetCreativityConnection' not found.");
builder.Services.AddDbContext<SweetCreativityContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SweetCreativityContext>();

builder.Services.AddScoped<IListingReposotory, ListingReposotory>();
builder.Services.AddScoped<IUserReposotory, UserReposotory>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

