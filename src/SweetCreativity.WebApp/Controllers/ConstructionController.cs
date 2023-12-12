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
    public class ConstructionController : Controller
    {
        private readonly IConstructionReposotory constructionReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SweetCreativityContext _context;
        public ConstructionController(IConstructionReposotory constructionReposotory, IWebHostEnvironment webHostEnviroment, [FromServices] SweetCreativityContext context)
        {
            this.constructionReposotory = constructionReposotory;
            this.webHostEnvironment = webHostEnviroment;
            this._context = context;
        }
        public IActionResult Index()
        {
            var constructions = constructionReposotory.GetAll();
            var statusList = _context.Statuses.ToList();

            foreach (var construction in constructions)
            {
                construction.Status = statusList.FirstOrDefault(s => s.Id == construction.StatusId);
            }

            return View(constructions);
        }

        public IActionResult Details(int id)
        {
            var construction = _context.Constructions
        .Include(l => l.Comments)
        .FirstOrDefault(l => l.Id == id);

            if (construction == null)
            {
                return NotFound();
            }

            // Отримати список статусів з бази даних
            var statusList = _context.Statuses.ToList();

            // Передати список статусів у ViewBag
            ViewBag.StatusList = new SelectList(statusList, "Id", "StatusName");

            return View(construction);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Construction());
        }
        [HttpPost]
        public IActionResult Create(Construction model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.CoverPath = "/img/construction/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/construction/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                constructionReposotory.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateStatus(int id, int statusId)
        {
            var construction = _context.Constructions.Find(id);
            if (construction != null)
            {
                construction.StatusId = statusId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddComment(int constructionId, string textComment)
        {
            var construction = _context.Constructions
                .Include(l => l.Comments)
                .FirstOrDefault(l => l.Id == constructionId);

            if (construction == null)
            {
                return NotFound();
            }

            var newComment = new Comment
            {
                TextComment = textComment,
                CreatedAtResponse = DateTime.Now
            };

            construction.Comments.Add(newComment);
            _context.SaveChanges();

            // Після додавання відгуку перенаправте користувача на сторінку оголошення
            return RedirectToAction("Details", new { id = constructionId });
        }

    }



}