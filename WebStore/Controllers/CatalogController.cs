using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Filters;
using WebStore.Infrastructure.Intefaces;
using WebStore.ViewsModels;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;

        public CatalogController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Shop(int? categoryId, int? brandId)
        {
            // Получение списока отфильтрованных продуктов
            var products = _productData.GetProducts(new ProductFilter
            {
                BrandId = brandId,
                CategoryId = categoryId
            });

            // Конвертация в CatalogViewModel
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = categoryId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}