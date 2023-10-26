using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;
using System.Data;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SweetCreativity.WebApp.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingReposotory listingReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SweetCreativityContext _context;

        public ListingController(IListingReposotory listingReposotory,
            IWebHostEnvironment webHostEnviroment, [FromServices] SweetCreativityContext context)
        {
            this.listingReposotory = listingReposotory;
            this.webHostEnvironment = webHostEnviroment;
            this._context = context;
        }
        //public ListingController(SweetCreativityContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            return View(listingReposotory.GetAll());
        }

        public IActionResult Details(int id)
        {
            //return View(listingReposotory.Get(id));
            var listing = _context.Listings
        .Include(l => l.Category) // Завантажуємо категорію
        .FirstOrDefault(l => l.Id == id);

            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);


        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View(new Listing());
        //}

        [HttpGet]
        public IActionResult Create()
        {
            // Отримайте список категорій з бази даних
            var categories = _context.Categories.ToList();

            // Передайте список категорій у ваше представлення
            ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");

            // Створіть пустий об'єкт Listing та передайте його у представлення
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


            var categories = _context.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");
            return View(model);
        }

        //if (ModelState.IsValid)
        //{

        //    listingReposotory.Add(item);
        //    //listingReposotory.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        //return View(item); 
        //}

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
            var item = listingReposotory.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            // Отримайте список категорій для випадаючого списку
            var categories = _context.Categories.ToList();

            // Передайте список категорій у ваше представлення
            ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");

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
                    var existingItem = listingReposotory.Get(item.Id);

                    if (existingItem != null)
                    {
                        existingItem.Title = item.Title;
                        existingItem.Description = item.Description;
                        existingItem.Product = item.Product;
                        existingItem.CreatedAtListing = item.CreatedAtListing;
                        existingItem.Location = item.Location;
                        existingItem.Price = item.Price;
                        existingItem.Weight = item.Weight;

                        if (item.CoverFile != null)
                        {
                            // Обробіть завантажене зображення, якщо воно було вибране
                            string wwwRootPath = webHostEnvironment.WebRootPath;
                            string fileName = Path.GetFileNameWithoutExtension(item.CoverFile.FileName);
                            string extension = Path.GetExtension(item.CoverFile.FileName);
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            existingItem.CoverPath = "/img/listing/" + fileName;
                            string path = Path.Combine(wwwRootPath, "img/listing", fileName);

                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                item.CoverFile.CopyTo(fileStream);
                            }
                        }

                        existingItem.CategoryId = item.CategoryId;

                        listingReposotory.Update(existingItem);
                        listingReposotory.Save();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    // Обробте помилку при оновленні даних, якщо вона виникла
                    // Виведіть або збережіть повідомлення про помилку для подальшого аналізу
                    return View(item);
                }
            }
            return View(item);
        }

        //[HttpPost]
        //public IActionResult Edit(Listing item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Отримайте запис для оновлення з репозиторію
        //            var existingItem = listingReposotory.Get(item.Id);

        //            if (existingItem != null)
        //            {
        //                // Оновіть дані, які ви хочете змінити
        //                existingItem.Title = item.Title;
        //                existingItem.Description = item.Description;
        //                existingItem.Product = item.Product;
        //                existingItem.CreatedAtListing = item.CreatedAtListing;
        //                existingItem.Location = item.Location;
        //                existingItem.Price = item.Price;
        //                existingItem.Weight = item.Weight;

        //                // Оновіть ID категорії
        //                existingItem.CategoryId = item.CategoryId;

        //                // Збережіть зміни в репозиторії
        //                listingReposotory.Update(existingItem);
        //                listingReposotory.Save();

        //                return RedirectToAction(nameof(Index));
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Обробте помилку при оновленні даних, якщо вона виникла
        //            // Виведіть або збережіть повідомлення про помилку для подальшого аналізу
        //            return View(item);
        //        }
        //    }
        //    return View(item);
        //}



    }
}



