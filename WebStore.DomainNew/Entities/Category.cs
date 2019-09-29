using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Сущность секция
    /// </summary>
    [Table("Category")]
    public class Category : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Родительская секция (при наличии)
        /// </summary>
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentSection { get; set; }

        /// <summary>
        /// Порядок
        /// </summary
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
