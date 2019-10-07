namespace WebStore.DomainNew.Entities.Base.Interfaces
{
    /// <summary>
    /// Сущность с именем
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }
    }
}
