namespace WebStore.DomainNew.Entities.Base.Interfaces
{
    /// <summary>
    /// Сущность с заказом
    /// </summary>
    public interface IOrderedEntity
    {
        /// <summary>
        /// Порядок
        /// </summary>
        int Order { get; set; }
    }
}
