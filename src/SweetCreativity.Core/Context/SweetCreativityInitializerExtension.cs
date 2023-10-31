using Microsoft.EntityFrameworkCore;
using SweetCreativity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Core.Context
{
    public static class SweetCreativityInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            seedListing(builder);
            seedCategory(builder);
            seedUser(builder);
            seedOrder(builder);
        }
        private static void seedOrder(ModelBuilder builder)
        {
            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    NameOrder = "Торт Наполеон",
                    Quantity = 1,
                    TotalPrice = 250,
                    CreatedAtOrder = DateTime.Now,
                    CustomerNumber = 0985684335,
                    UserId = 1,
                    ListingId = 1,
                },
                new Order
                {
                    Id = 2,
                    NameOrder = "Торт Спартак",
                    Quantity = 1,
                    TotalPrice = 400,
                    CreatedAtOrder = DateTime.Now,
                    CustomerNumber = 0985688735,
                    UserId = 2,
                    ListingId = 2,
                }
                );
        }

        private static void seedUser(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Тетяна2.0",
                    Email = "taniabondar@gmail.com",
                    Password = "2.0taniab",
                    FullName = "Тетяна Бондар",
                    PhoneNumber = 0985674335,
                    UrlSocialnetwork = "@taniabondar23"
                },
                new User
                {
                    Id = 2,
                    UserName = "ОленаT",
                    Email = "olenatkachuk@gmail.com",
                    Password = "123olenatt",
                    FullName = "Олена Ткачук",
                    PhoneNumber = 0986390482,
                    UrlSocialnetwork = "@olena_tkachuk"
                }
                );
        }
        private static void seedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     NameCategory = "Торти"
                 },
                  new Category
                  {
                      Id = 2,
                      NameCategory = "Тістечка"
                  },
                  new Category
                  {
                      Id = 3,
                      NameCategory = "Цукерки"
                  },
                  new Category
                  {
                      Id = 4,
                      NameCategory = "Печиво"
                  },
                  new Category
                  {
                      Id = 5,
                      NameCategory = "Вафлі"
                  }
                 );
        }
        static void seedListing(ModelBuilder builder)
        {
            builder.Entity<Listing>().HasData(
              new Listing
              {
                  Id = 1,
                  Title = "Торт Наполеон",
                  Description = " Це відомий і популярний торт, який складається з тонких шарів бісквіту і вершкового крему.",
                  Product = "Борошно, вершкове масло, яйця, оцет, цукор, ванільний цукор або ванільний екстракт, кукурудзяний крохмаль, вершки, сіль, прикраси (за бажанням).",
                  Location = "Lviv",
                  CategoryId = 1,
                  UserId = 1,
                  Price = 165,
                  Weight = 1000
              },
              new Listing
              {
                  Id = 2,
                  Title = "Мафіни",
                  Description = "Гармонійне поєднання повітряного шоколадного тіста мафіну з ніжно-солодкою вершковою начинкою.",
                  Product = "Борошно пшеничне, цукор-пісок, суміш “Мафін шоколадний”, олія рослинна, меланж, вода. Начинка: згущене молоко “Іриска”з вершками.",
                  Location = "Rivne",
                  CategoryId = 2,
                  UserId = 2,
                  Price = 180,
                  Weight = 80
              }
                );
        }

 
    }
}