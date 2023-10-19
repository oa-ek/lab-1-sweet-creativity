using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SweetCreativity.WebApp.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingReposotory listingReposotory;


        public ListingController(IListingReposotory listingReposotory)
        {
            this.listingReposotory = listingReposotory;
        }
        public IActionResult Index()
        {
            return View(listingReposotory.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(listingReposotory.Get(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Listing());
        }

        [HttpPost]
        public IActionResult Create(Listing item)
        {
            if (ModelState.IsValid)
            {

                listingReposotory.Add(item);
                //listingReposotory.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(item); 
        }

        //public IActionResult Delete(int id)
        //{
        //    return View(listingReposotory.Get(id));
        //}

        //[HttpPost]
        //public IActionResult Delete( Listing listing)
        //{
        //    listingReposotory.Delete(listing);

        //    return RedirectToAction("Index");
        //}

        //////////////////////
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    Listing listingToDelete = listingReposotory.Get(id);

        //    if (listingToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(listingToDelete);
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    listingReposotory.Delete(id);

        //    listingReposotory.Save();
        //    return RedirectToAction("Index");
        //    //return RedirectToAction(nameof(Index));
        //    //return RedirectToAction("DeleteConfirmed");

        //}
        public IActionResult Delete(int id)
        {
            return View(listingReposotory.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Listing listing)
        {
            listingReposotory.Delete(listing);

            return RedirectToAction("Index");
        }
        //////////////////////

        //        [HttpGet]
        public IActionResult Edit(int id)
        {
            Listing item = listingReposotory.Get(id); // Отримуємо елемент за його ID
            if (item == null)
            {
                return NotFound(); // Перевіряємо, чи знайдено елемент
            }

            return View(item);
        }
        //public IActionResult Edit(int id)
        //{
        //    return View(listingRepository.Find(id);
        //}

        [HttpPost]
        public IActionResult Edit(Listing item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Отримайте запис для оновлення з репозиторію (замість контексту бази даних)
                    var existingItem = listingReposotory.Get(item.Id);

                    if (existingItem != null)
                    {
                        // Оновіть дані, які ви хочете змінити
                        existingItem.Title = item.Title;
                        existingItem.Description = item.Description;
                        existingItem.Product = item.Product;
                        existingItem.CreatedAtListing = item.CreatedAtListing;
                        existingItem.Location = item.Location;
                        existingItem.Price = item.Price;
                        existingItem.Weight = item.Weight;
                        // і т.д. для інших полів

                        // Збережіть зміни в репозиторії
                        listingReposotory.Update(existingItem);
                        listingReposotory.Save();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Якщо запис не знайдено, обробіть це відповідним чином
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    // Обробте помилку при оновленні даних, якщо вона виникла
                    // Виведіть або збережіть повідомлення про помилку для подальшого аналізу
                    // Ви можете також відправити користувачеві повідомлення про помилку, якщо це потрібно
                    return View(item);
                }
            }
            return View(item);
        }


    }

}



