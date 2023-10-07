using Microsoft.AspNetCore.Mvc;
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
    }
}
