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
                }
                );
         }
        private static void seedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     NameCategory = "Бісквітні торти"
                 },
                  new Category
                  {
                      Id = 2,
                      NameCategory = "Вафельні торти"
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
              }
                );
        }

    }
}
