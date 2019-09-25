using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Intefaces
{
    /// <summary>
    /// Интерфейс для сервиса продуктов:
    /// </summary>
    public interface IProductData
    {
        /// <summary>
        /// Запрос коллекции секций
        /// </summary>
        /// <returns>Коллекция секций</returns>
        IEnumerable<Category> GetCategories();
        /// <summary>
        /// Запрос коллекции брендов
        /// </summary>
        /// <returns>Коллекция брендов</returns>
        IEnumerable<Brand> GetBrands();
    }
}
