using Microsoft.AspNetCore.Mvc;
using SweetCreativity.Reposotories.Interfaces;

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
    }
}
