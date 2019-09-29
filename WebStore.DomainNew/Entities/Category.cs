using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Сущность секция
    /// </summary>
    public class Category : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Родительская секция (при наличии)
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Порядок
        /// </summary
        public int Order { get; set; }
    }



}
