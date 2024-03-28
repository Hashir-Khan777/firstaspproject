using firstaspapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace firstaspapp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly MarketContext db;

        public CategoryController(MarketContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int? id)
        {
            ViewBag.Action = "edit";

            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        public IActionResult Delete(int Id)
        {
            var category = db.Categories.Find(Id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                CategoriesRepository.DeleteCategory(Id);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var cat = db.Categories.Find(category.Id);
            if (ModelState.IsValid)
            {
                if (cat != null)
                {
                    cat.Name = category.Name;
                    cat.Description = category.Description;
                    db.SaveChanges();
                }
                CategoriesRepository.UpdateCategory(category.Id, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
