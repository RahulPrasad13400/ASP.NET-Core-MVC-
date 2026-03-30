using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace e_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll().ToList();
            return View(productList);
        }

        // CREATE PRODUCT
        [HttpGet]
        public IActionResult Create()
        {
            // SelectListItem - special class used for dropdown options
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id,
                Text = c.Name
            });

            //ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _unitOfWork.Product.Add(product);
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }

        // UPDATE PRODUCT
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();
            
            Product product = _unitOfWork.Product.Get(p => p.Id == id);

            if(product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(!ModelState.IsValid)
                return View(product);

            _unitOfWork.Product.Update(product);
            TempData["success"] = "Product Updated successfully";
            return RedirectToAction("Index");
        }

        // DELETE PRODUCT
        [HttpGet]
        public IActionResult Delete(string id) 
        {
            Product product = _unitOfWork.Product.Get(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _unitOfWork.Product.Remove(product);
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
