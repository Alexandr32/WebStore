using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities;

namespace WebStore.DomainNew.Filters
{
    /// <summary>
    /// Класс для фильтрации товаров
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Категоря, к которой принадлежит товар
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }
       
    }
}
