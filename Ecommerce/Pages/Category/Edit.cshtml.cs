using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace Ecommerce.Pages.Category
{
    public class EditModel(MongoService mongoService) : PageModel
    {
        private readonly MongoService _mongoService = mongoService;
        [BindProperty]
        public Ecommerce.Models.Category Category { get; set; }

        public void OnGet(string id)
        {
            Ecommerce.Models.Category category = _mongoService.GetCollection<Ecommerce.Models.Category>("categories")
                .Find(category => category.Id == id).First();
            
            Category = category;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _mongoService.GetCollection<Ecommerce.Models.Category>("categories")
                .ReplaceOne(c => c.Id == Category.Id, Category);

            TempData["success"] = "Category Updated Successfully";

            return RedirectToPage("/Category/Index");
        }
    }
}
