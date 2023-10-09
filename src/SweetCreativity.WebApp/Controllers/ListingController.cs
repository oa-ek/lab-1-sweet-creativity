using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;

namespace SweetCreativity.WebApp.Controllers
{
    public class ListingController : Controller
    {
        private  readonly IListingReposotory listingReposotory;
        
            
         public ListingController (IListingReposotory listingReposotory)
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
    }
}
