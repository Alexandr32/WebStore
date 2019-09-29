using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Сущность бренд
    /// </summary>
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Порядок
        /// </summary
        public int Order { get; set; }
        /// <summary>
        /// Список продуктов относящихся к бренду
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }



}
