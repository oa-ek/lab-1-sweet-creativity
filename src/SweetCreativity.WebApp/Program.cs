using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SweetCreativityConnection") ?? throw new InvalidOperationException("Connection string 'SweetCreativityConnection' not found.");
builder.Services.AddDbContext<SweetCreativityContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequiredLength = 4;
    }).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SweetCreativityContext>();

//builder.Services.AddSingleton<UserManager<User>>();
builder.Services.AddScoped<IListingReposotory, ListingReposotory>();
builder.Services.AddScoped<IUserReposotory, UserReposotory>();
builder.Services.AddScoped<IOrderReposotory, OrderReposotory>();
builder.Services.AddScoped<IConstructionReposotory, ConstructionReposotory>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

