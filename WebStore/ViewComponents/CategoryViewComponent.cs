using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Intefaces;
using WebStore.ViewsModels;

namespace WebStore.ViewComponents
{
    /// <summary>
    /// ViewComponent, который будет отображать секции, загружаемые из базы
    /// </summary>
    public class CategoryViewComponent : ViewComponent
    {
        /// <summary>
        /// Интерфейс для сервиса продуктов
        /// </summary>
        private readonly IProductData _productData;

        public CategoryViewComponent(IProductData productData)
        {
            _productData = productData;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = GetCategories();
            return View(categories);
        }
        private List<CategoryViewModel> GetCategories()
        {
            var categories = _productData.GetCategories();
           
            // получим и заполним родительские категории
            var parentSections = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentCategories = new List<CategoryViewModel>();
            foreach (var parentCategory in parentSections)
            {
                parentCategories.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategory = null
                });
            }
            // получим и заполним дочерние категории
            foreach (var CategoryViewModel in parentCategories)
            {
                var childCategories = categories.Where(c => c.ParentId == CategoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    CategoryViewModel.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = CategoryViewModel
                    });
                }
                CategoryViewModel.ChildCategories = CategoryViewModel.ChildCategories.OrderBy(c => c.Order).ToList();
            }
            parentCategories = parentCategories.OrderBy(c => c.Order).ToList();
            return parentCategories;
        }
    }
}
