using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly MongoService _mongoService;
        [BindProperty]
        public Ecommerce.Models.Category Category { get; set; }
        public CreateModel(MongoService mongoService)
        {
            _mongoService = mongoService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            

            _mongoService.GetCollection<Ecommerce.Models.Category>("categories").InsertOne(Category);

            TempData["success"] = "Category Created Successfully";

            return RedirectToPage("/Category/Index");
        }
    }
}
