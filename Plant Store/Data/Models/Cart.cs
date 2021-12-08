using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Store.Data.Models
{
    public class Cart
    {
        public string CartId { get; set; }

        public List<CartItem> ShopItems { get; set; }

        private readonly DataContext dataContext;

        public Cart(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DataContext>();
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cartId);

            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart(Plant plant)
        {
            dataContext.CartItem.Add(new CartItem
            {
                CartId = CartId,
                Plant = plant,
                Price = plant.Price
            });

            dataContext.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return dataContext.CartItem.Where(c => c.CartId == CartId).Include(s => s.Plant).ToList();
        }

    }
}
