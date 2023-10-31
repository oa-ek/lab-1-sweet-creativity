using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;

namespace SweetCreativity.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReposotory orderReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        public OrderController(IOrderReposotory orderReposotory, IWebHostEnvironment webHostEnviroment)
        {
            this.orderReposotory = orderReposotory;
            this.webHostEnvironment = webHostEnviroment;
        }
        public IActionResult Index()
        {
            return View(orderReposotory.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(orderReposotory.Get(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Create(Order model)
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

                orderReposotory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
        public IActionResult Delete(int id)
        {
            return View(orderReposotory.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Order order)
        {
            orderReposotory.Delete(order);

            return RedirectToAction("Index");
        }
    }


}
