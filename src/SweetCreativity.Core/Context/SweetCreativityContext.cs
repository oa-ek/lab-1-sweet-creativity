using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetCreativity.Core.Entities;

namespace SweetCreativity.WebApp.Data;

public class SweetCreativityContext : IdentityDbContext
{
    public SweetCreativityContext(DbContextOptions<SweetCreativityContext> options)
        : base(options)
    {
    }


    public DbSet<User> Users => Set<User>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Response> Responses => Set<Response>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<ListingImage> ListingImages => Set<ListingImage>();

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
        //optionsBuilder.UseSqlServer("Server=.;Database=SweetCreativityDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
       // base.OnConfiguring(optionsBuilder);
   // }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Listing>()
        .HasOne(l => l.UserId)  // Кожен Listing належить одному User
        .WithMany(u => u.Listings)  // У User може бути багато Listings
        .HasForeignKey(l => l.UserId);  // Зовнішній ключ у таблиці Listings

        builder.Entity<Listing>()
    .HasOne(l => l.CategoryId)  // Кожен Listing належить одній Category
    .WithMany(c => c.Listings)  // У Category може бути багато Listings
    .HasForeignKey(l => l.CategoryId);  // Зовнішній ключ у таблиці Listings

        builder.Entity<Order>()
    .HasOne(o => o.StatusId)  // Кожен Order має один Status
    .WithMany()  // У Status може бути багато Orders
    .HasForeignKey(o => o.StatusId);  // Зовнішній ключ у таблиці Orders

        builder.Entity<User>()
    .Property(u => u.Email)
    .IsRequired()
    .HasMaxLength(256)
    .IsUnicode(false);

        builder.Entity<Category>()
    .HasIndex(c => c.NameCategory)
    .IsUnique();


        base.OnModelCreating(builder);
    }


} 
