using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace e_commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MongoService _mongoService;
        public CategoryController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _mongoService.GetCollection<Category>("categories").Find(_ => true).ToList(); 
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
            
            _mongoService.GetCollection<Category>("categories").InsertOne(category);
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if(string.IsNullOrWhiteSpace(id))
                return NotFound();
            
            Category category = _mongoService.GetCollection<Category>("categories")
                .Find(category => category.Id == id).FirstOrDefault();

            if(category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            IMongoCollection<Category> categoryCollection = _mongoService.GetCollection<Category>("categories");
            categoryCollection.ReplaceOne(c => c.Id == category.Id, category);
            TempData["success"] = "Category updated successfully";  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            Category category = _mongoService.GetCollection<Category>("categories")
                .Find(category => category.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            IMongoCollection<Category> categoryCollection = _mongoService.GetCollection<Category>("categories");
            categoryCollection.DeleteOne(c => c.Id == category.Id);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
