using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SweetCreativity.Core.Entities;

namespace SweetCreativity.Core.Context;

public class SweetCreativityContext : IdentityDbContext<User>
{
    public SweetCreativityContext(DbContextOptions<SweetCreativityContext> options)
        : base(options)
    {

    }
    //public DbSet<User> Users => Set<User>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Construction> Constructions => Set<Construction>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Response> Responses => Set<Response>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Rating> Ratings => Set<Rating>();
    //public DbSet<ListingImage> ListingImages => Set<ListingImage>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Listing>()
        .HasOne(l => l.User)  // Кожен Listing належить одному User
        .WithMany(u => u.Listings)  // У User може бути багато Listings
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Cascade);   // Зовнішній ключ у таблиці Listings


        modelBuilder.Entity<Listing>()
    .HasOne(l => l.Category)  // Кожен Listing належить одній Category
    .WithMany(c => c.Listings)  // У Category може бути багато Listings
    .HasForeignKey(l => l.CategoryId)
    .OnDelete(DeleteBehavior.Cascade);  // Зовнішній ключ у таблиці Listings

        modelBuilder.Entity<Order>()
    .HasOne(o => o.Status)  // Кожен Order має один Status
    .WithMany(o => o.Orders) // У Status може бути багато Orders
    .HasForeignKey(o => o.StatusId)
    .OnDelete(DeleteBehavior.Cascade);// Зовнішній ключ у таблиці Orders

        modelBuilder.Entity<Construction>()
    .HasOne(c => c.Status)  // Кожен Construction має один Status
    .WithMany(c => c.Constructions) // У Status може бути багато Constructions
    .HasForeignKey(c => c.StatusId)
    .OnDelete(DeleteBehavior.Cascade);// Зовнішній ключ у таблиці Constructions

        modelBuilder.Entity<Order>()
   .HasOne(o => o.User)  
   .WithMany(o => o.Orders) 
   .HasForeignKey(o => o.UserId)
   .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Construction>()
   .HasOne(o => o.User)
   .WithMany(o => o.Constructions)
   .HasForeignKey(o => o.UserId)
   .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
    .Property(u => u.Email)
    .IsRequired()
    .HasMaxLength(256)
    .IsUnicode(false);

        modelBuilder.Entity<Category>()
    .HasIndex(c => c.NameCategory)
    .IsUnique();

        modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }
}