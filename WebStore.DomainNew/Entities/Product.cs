using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Сущность продукт
    /// </summary>
    [Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Категория, к которой принадлежит товар
        /// </summary>
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }
}
