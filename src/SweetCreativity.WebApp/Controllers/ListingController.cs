using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SweetCreativity.WebApp.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingReposotory listingReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SweetCreativityContext context; // Отримуємо контекст бази даних

        public ListingController(IListingReposotory listingReposotory,
            IWebHostEnvironment webHostEnviroment)
        {
            this.listingReposotory = listingReposotory;
            this.webHostEnvironment = webHostEnviroment;
        }
        public IActionResult Index()
        {
            return View(listingReposotory.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(listingReposotory.Get(id));
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View(new Listing());
        //}

        [HttpGet]
        public IActionResult Create()
        {
            // Отримуємо список категорій з контексту бази даних
            List<Category> categories = context.Categories.ToList();

            // Перетворюємо список категорій на список рядків для випадаючого списку
            List<string> categoryNames = categories.Select(c => c.NameCategory).ToList();

            // Передаємо список категорій у ViewBag для відображення у представленні
            ViewBag.CategoryNames = categoryNames;

            return View(new Listing());
        }



        [HttpPost]
        public IActionResult Create(Listing model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.CoverPath = "/img/listing/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/listing/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                listingReposotory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

            //if (ModelState.IsValid)
            //{

            //    listingReposotory.Add(item);
            //    //listingReposotory.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(item); 
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