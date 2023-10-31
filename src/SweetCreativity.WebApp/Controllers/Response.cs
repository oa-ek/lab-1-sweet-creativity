//using Microsoft.AspNetCore.Mvc;
//using SweetCreativity.Core.Context;
//using SweetCreativity.Core.Entities;
//using SweetCreativity.WebApp.Controllers;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using NuGet.Protocol.Core.Types;
//using SweetCreativity.Core.Context;
//using SweetCreativity.Core.Entities;
//using SweetCreativity.Reposotories.Interfaces;
//using SweetCreativity.Reposotories.Repos;
//using System.Data;
//using System.Linq;
//using static System.Runtime.InteropServices.JavaScript.JSType;


//public class RatingController : Controller
//{
//    private readonly SweetCreativityContext _context;

//    public RatingController(SweetCreativityContext context)
//    {
//        _context = context;
//    }

//    [HttpPost]
//    public IActionResult AddRating(int listingId, int ratingPoint, string textRating)
//    {
//        // Отримайте поточного користувача (ви можете замінити це на відповідний спосіб отримання користувача)
//        var user = // Отримайте користувача, який залишив відгук;

//        // Отримайте оголошення, до якого буде додаватися відгук
//        var listing = _context.Listings.FirstOrDefault(l => l.Id == listingId);

//        if (listing == null)
//        {
//            return NotFound();
//        }

//        // Створіть новий відгук
//        var newRating = new Rating
//        {
//            TextRating = textRating,
//            RatingPoint = ratingPoint,
//            CreatedAtRating = DateTime.Now,
//            ListingId = listing.Id,
//            UserId = user.Id
//        };

//        // Додайте новий відгук до бази даних
//        _context.Ratings.Add(newRating);
//        _context.SaveChanges();

//        // Оновіть середній рейтинг оголошення (ваша логіка розрахунку середнього рейтингу)
//        double averageRating = // Розрахунок середнього рейтингу;

//        return RedirectToAction("Details", "Listing", new { id = listingId });
//    }

//    [HttpPost]
//    public IActionResult DeleteRating(int ratingId)
//    {
//        var rating = _context.Ratings.FirstOrDefault(r => r.Id == ratingId);

//        if (rating == null)
//        {
//            return NotFound();
//        }

//        _context.Ratings.Remove(rating);
//        _context.SaveChanges();

//        // Оновіть середній рейтинг оголошення після видалення відгуку (ваша логіка розрахунку середнього рейтингу)

//        return RedirectToAction("Details", "Listing", new { id = rating.ListingId });
//    }
//}
