using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Filters;
using WebStore.Infrastructure.Intefaces;
using WebStore.ViewsModels;

namespace WebStore.Infrastructure.Implementation
{
    /// <summary>
    /// Сервис для хранения данных корзины в куках
    /// </summary>
    public class CookieCartService : ICartService
    {
        private readonly IProductData _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cartName;

        private Cart Cart
        {
            get
            {
                var cookie = _httpContextAccessor
                                .HttpContext
                                .Request
                                .Cookies[_cartName];
                string json = string.Empty;
                Cart cart = null;

                if (cookie == null)
                {
                    cart = new Cart { Items = new List<CartItem>() };
                    json = JsonConvert.SerializeObject(cart);

                    _httpContextAccessor
                          .HttpContext
                          .Response
                          .Cookies
                          .Append(
                             _cartName,
                             json,
                             new CookieOptions
                             {
                                 Expires = DateTime.Now.AddDays(1)
                             });
                    return cart;
                }

                json = cookie;
                cart = JsonConvert.DeserializeObject<Cart>(json);

                _httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Delete(_cartName);

                _httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Append(
                          _cartName,
                          json,
                          new CookieOptions()
                          {
                              Expires = DateTime.Now.AddDays(1)
                          });

                return cart;
            }

            set
            {
                var json = JsonConvert.SerializeObject(value);

                _httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Delete(_cartName);
                _httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Append(
                           _cartName,
                           json,
                           new CookieOptions()
                           {
                               Expires = DateTime.Now.AddDays(1)
                           });
            }
        }

        
        public CookieCartService(
           IProductData productService,
           IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;

            _cartName = "cart"
            + (_httpContextAccessor
                 .HttpContext.User.Identity.IsAuthenticated ? 
                 _httpContextAccessor.HttpContext.User.Identity.Name : "");
        }
        /// <summary>
        /// Уменьшение кол-ва товара на единицу
        /// </summary>
        /// <param name="id"></param>
        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 0)
                    item.Quantity--;

                if (item.Quantity == 0)
                    cart.Items.Remove(item);
            }

            Cart = cart;
        }
        /// <summary>
        /// Удаление элемента из корзины
        /// </summary>
        /// <param name="id"></param>
        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            Cart = cart;
        }
        /// <summary>
        /// Удалить все из корзины
        /// </summary>
        public void RemoveAll()
        {
            Cart = new Cart { Items = new List<CartItem>() };
        }
        /// <summary>
        /// Добавляем элемент в корзину
        /// </summary>
        /// <param name="id"></param>
        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
                item.Quantity++;
            else
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });

            Cart = cart;
        }
        /// <summary>
        /// Приводит список продуктов в viewModel
        /// </summary>
        /// <returns></returns>
        public CartViewModel TransformCart()
        {
            var products = _productService.GetProducts(new ProductFilter()
            {
                Ids = Cart.Items.Select(i => i.ProductId).ToList()
            }).Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                BrandName = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();

            var r = new CartViewModel
            {
                Items = Cart.Items.ToDictionary(
                            x => products.First(y => y.Id == x.ProductId),
                            x => x.Quantity)
            };

            return r;
        }
    }
}
