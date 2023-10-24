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
    public class UserController : Controller
    {
        private readonly IUserReposotory userReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(IUserReposotory userReposotory,
            IWebHostEnvironment webHostEnviroment)
        {
            this.userReposotory = userReposotory;
            this.webHostEnvironment = webHostEnviroment;
        }
        public IActionResult Index()
        {
            return View(userReposotory.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(userReposotory.Get(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.CoverPath = "/img/user/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/user/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                userReposotory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        
        }

        public IActionResult Delete(int id)
        {
            return View(userReposotory.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            userReposotory.Delete(user);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            User item = userReposotory.Get(id); // Отримуємо елемент за його ID
            if (item == null)
            {
                return NotFound(); // Перевіряємо, чи знайдено елемент
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(User item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = userReposotory.Get(item.Id);

                    if (existingItem != null)
                    {
                        existingItem.UserName = item.UserName;
                        existingItem.Email = item.Email;
                        existingItem.Password = item.Password;
                        existingItem.FullName = item.FullName;
                        existingItem.PhoneNumber = item.PhoneNumber;
                        existingItem.UrlSocialnetwork = item.UrlSocialnetwork;

                        userReposotory.Update(existingItem);
                        userReposotory.Save();

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



