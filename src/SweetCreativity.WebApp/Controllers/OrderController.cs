using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;

namespace SweetCreativity.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReposotory orderReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SweetCreativityContext _context;
        public OrderController(IOrderReposotory orderReposotory, IWebHostEnvironment webHostEnviroment, [FromServices] SweetCreativityContext context)
        {
            this.orderReposotory = orderReposotory;
            this.webHostEnvironment = webHostEnviroment;
            this._context = context;
        }
        public IActionResult Index()
        {
            var orders = orderReposotory.GetAll();
            var statusList = _context.Statuses.ToList();

            foreach (var order in orders)
            {
                order.Status = statusList.FirstOrDefault(s => s.Id == order.StatusId);
            }

            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);

            // Отримати список статусів з бази даних
            var statusList = _context.Statuses.ToList();

            // Передати список статусів у ViewBag
            ViewBag.StatusList = new SelectList(statusList, "Id", "StatusName");
            return View(orderReposotory.Get(id));
        }
        [HttpGet]
        //[HttpGet("Create/{listingId}")]
        public IActionResult Create(int listingId)
        {
            var listing = _context.Listings.FirstOrDefault(l => l.Id == listingId);

            if (listing == null)
            {
                return NotFound();
            }

            var order = new Order
            {
                Listing = listing,
                NameOrder = listing.Title,
                PriceOne = listing.Price,
                ListingPhotoPath = listing.CoverPath,
                //CoverPath = listing.CoverPath,
                // Інші властивості order
            };

            return View(order);
        }
        [HttpPost]
        public IActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
                //string wwwRootPath = webHostEnvironment.WebRootPath;

                //string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                //string extension = Path.GetExtension(model.CoverFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //model.CoverPath = "/img/user/" + fileName;
                //string path = Path.Combine(wwwRootPath + "/img/user/", fileName);

                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    model.CoverFile.CopyTo(fileStream);
                //}

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

        ////[HttpPost]
        ////public IActionResult UpdateStatus(int id, int statusId)
        ////{
        ////    var order = _orderRepository.Get(id);
        ////    if (order != null)
        ////    {
        ////        order.StatusId = statusId;
        ////        _orderRepository.Update(order);
        ////    }

        ////    return RedirectToAction("Details", new { id });
        ////}
        ///
        [HttpPost]
        public IActionResult UpdateStatus(int id, int statusId)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.StatusId = statusId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }



}