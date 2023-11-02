using Microsoft.AspNetCore.Identity;
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
            (string admId, string clId, string selId) = seedUsersAndRoles(builder);
            seedListing(builder, new string[] { selId, admId });
            seedCategory(builder);
            //seedUser(builder);
            seedOrder(builder, new string[] { clId, admId });
            seedStatus(builder);
        }
        private static void seedStatus(ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    StatusName = "Прийнято"
                },
                 new Status
                 {
                     Id = 2,
                     StatusName = "Виконується"
                 },
                new Status
                {
                    Id = 3,
                    StatusName = "Не прийнято"
                }
                );


        }
        private static void seedOrder(ModelBuilder builder, string[] clientIds)
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
                    UserId = clientIds[0],
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
                    UserId = clientIds[1],
                    ListingId = 2,
                }
                );
        }

        //private static void seedUser(ModelBuilder builder)
        //{
        //    builder.Entity<User>().HasData(
        //        new User
        //        {
        //            Id = 1,
        //            UserName = "Тетяна2.0",
        //            Email = "taniabondar@gmail.com",
        //            Password = "2.0taniab",
        //            FullName = "Тетяна Бондар",
        //            PhoneNumber = 0985674335,
        //            UrlSocialnetwork = "@taniabondar23"
        //        },
        //        new User
        //        {
        //            Id = 2,
        //            UserName = "ОленаT",
        //            Email = "olenatkachuk@gmail.com",
        //            Password = "123olenatt",
        //            FullName = "Олена Ткачук",
        //            PhoneNumber = 0986390482,
        //            UrlSocialnetwork = "@olena_tkachuk"
        //        }
        //        );
        //}
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
        static void seedListing(ModelBuilder builder, string[] sellerIds)
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
                  UserId = sellerIds[0],
                  Price = 165,
                  Weight = 1000,
              },
              new Listing
              {
                  Id = 2,
                  Title = "Мафіни",
                  Description = "Гармонійне поєднання повітряного шоколадного тіста мафіну з ніжно-солодкою вершковою начинкою.",
                  Product = "Борошно пшеничне, цукор-пісок, суміш “Мафін шоколадний”, олія рослинна, меланж, вода. Начинка: згущене молоко “Іриска”з вершками.",
                  Location = "Rivne",
                  CategoryId = 2,
                  UserId = sellerIds[1],
                  Price = 180,
                  Weight = 80,
              }
                );
        }

        static (string, string, string) seedUsersAndRoles(ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string CLIENT_ROLE_ID = Guid.NewGuid().ToString();
            string SELLER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Id = CLIENT_ROLE_ID, Name = "Client", NormalizedName = "CLIENT" },
                new IdentityRole { Id = SELLER_ROLE_ID, Name = "Seller", NormalizedName = "SELLER" }
                );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string CLIENT_ID = Guid.NewGuid().ToString();
            string SELLER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "taniabondar@gmail.com",
                Email = "taniabondar@gmail.com",
                //Password = "2.0taniab",
                FullName = "Тетяна Бондар",
                PhoneNumber = 0985674335,
                UrlSocialnetwork = "@taniabondar23",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@SWEETCREATIVITY.COM",
                NormalizedUserName = "ADMIN@SWEETCREATIVITY.COM"
            };
            var client = new User
            {
                Id = CLIENT_ID,
                UserName = "olenatkachuk@gmail.com",
                Email = "olenatkachuk@gmail.com",
                //Password = "123olenatt",
                FullName = "Олена Ткачук",
                PhoneNumber = 0986390482,
                UrlSocialnetwork = "@olena_tkachuk",
                EmailConfirmed = true,
                NormalizedEmail = "CLIENT@SWEETCREATIVITY.COM",
                NormalizedUserName = "CLIENT@SWEETCREATIVITY.COM"
            };
            var seller = new User
            {
                Id = SELLER_ID,
                UserName = "melnykadrian@gmail.com",
                Email = "melnykadrian@gmail.com",
                //Password = "melnyk456",
                FullName = "Адріан Мельник",
                PhoneNumber = 0984568310,
                UrlSocialnetwork = "@adriannmelnykk",
                EmailConfirmed = true,
                NormalizedEmail = "SELLER@SWEETCREATIVITY.COM",
                NormalizedUserName = "SELLER@SWEETCREATIVITY.COM"
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$pass");
            client.PasswordHash = hasher.HashPassword(client, "client$pass");
            seller.PasswordHash = hasher.HashPassword(seller, "seller$pass");

            builder.Entity<User>().HasData(admin, client, seller);

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = SELLER_ROLE_ID,
                    UserId = ADMIN_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = SELLER_ROLE_ID,
                    UserId = SELLER_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = CLIENT_ROLE_ID,
                    UserId = CLIENT_ID
                }
                );
            return (ADMIN_ID, CLIENT_ID, SELLER_ID);
        }
    }
}