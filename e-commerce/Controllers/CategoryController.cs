using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace e_commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = [.. _categoryRepository.GetAll()];
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            if(category.Name == category.DisplayOrder.ToString())
                ModelState.AddModelError("name", "Name cannot be same as the Display Order");
            
            if (!ModelState.IsValid)
                return View(category);
            
            _categoryRepository.Add(category);
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if(string.IsNullOrWhiteSpace(id))
                return NotFound();

            Category category = _categoryRepository.Get(c => c.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            _categoryRepository.Update(category);

            TempData["success"] = "Category updated successfully";  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            Category category = _categoryRepository.Get(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _categoryRepository.Remove(category);

            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
