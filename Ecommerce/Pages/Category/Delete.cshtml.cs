using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace Ecommerce.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly MongoService _mongoService;
        [BindProperty]
        public Ecommerce.Models.Category Category { get; set; }
        public DeleteModel(MongoService mongoService)
        {
            _mongoService = mongoService;
        }
        public void OnGet(string id)
        {
            Ecommerce.Models.Category category = _mongoService.GetCollection<Ecommerce.Models.Category>("categories")
                .Find(category => category.Id == id).FirstOrDefault();

            Category = category;
        }

        public IActionResult OnPost()
        {
            Ecommerce.Models.Category category = _mongoService.GetCollection<Ecommerce.Models.Category>("categories")
                .Find(c => c.Id == Category.Id).FirstOrDefault();

            if(category is null)
                return NotFound();

            _mongoService.GetCollection<Ecommerce.Models.Category>("categories").DeleteOne(c => c.Id == Category.Id);

            TempData["success"] = "Category Deleted Successfully";

            return RedirectToPage("/Category/Index");
        }
    }
}
