using firstaspapp.Models;
using firstaspapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace firstaspapp.Controllers
{
    [Authorize(Policy = "Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }

        public IActionResult Edit([FromRoute] int id)
        {
            ViewBag.Action = "edit";

            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories(),
                Product = ProductsRepository.GetProductById(id) ?? new Product()
            };

            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }
    }
}
