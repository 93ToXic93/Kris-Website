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
            ProductModel modelToGive = new ProductModel();

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
                    return RedirectToAction(nameof(Error));
                }
            }

            return RedirectToAction(nameof(Menu));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductModel? productToUp = new ProductModel();

            try
            {
                productToUp = await _service.GetProductByIdAsync(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error));
            }

            return View(productToUp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel productModel)
        {

            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Not correct data!");
            }

            try
            {
                await _service.UpdateAsync(productModel);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error));
            }


            return RedirectToAction(nameof(Menu));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await _service.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error));
            }

            return RedirectToAction(nameof(Menu));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
