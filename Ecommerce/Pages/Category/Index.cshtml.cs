using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace Ecommerce.Pages.Category
{
    public class IndexModel(MongoService mongoService) : PageModel
    {
        private readonly MongoService _mongoService = mongoService;
        public List<Ecommerce.Models.Category> CategoryList { get; set; }

        public void OnGet()
        {
            CategoryList = _mongoService.GetCollection<Ecommerce.Models.Category>("categories").Find(category => true).ToList(); 
        }
    }
}
