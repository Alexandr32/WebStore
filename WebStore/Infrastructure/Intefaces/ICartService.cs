using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewsModels;

namespace WebStore.Infrastructure.Intefaces
{
    /// <summary>
    /// Сервис для работы с корзиной
    /// </summary>
    public interface ICartService
    {
        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void RemoveAll();
        void AddToCart(int id);
        CartViewModel TransformCart();
    }
}
