using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewsModels
{
    /// <summary>
    /// ViewModel для корзины
    /// </summary>
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }
        public int ItemsCount
        {
            get
            {
                return Items?.Sum(x => x.Value) ?? 0;
            }
        }
    }
}
