using Kris.Core.Contracts;
using Kris.Infrastructure.Data.Models;
using Kris.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kris.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            var products = await _service.GetAllAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ProductModel modelToGive = new ProductModel(); //To DO REQUIRED ISNT GIVEING IT !

            return View(modelToGive);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(model);
                }
                catch (Exception e)
                {
                    RedirectToAction(nameof(Error));
                }
            }

            return RedirectToAction(nameof(Menu));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
