using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.Entities
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
