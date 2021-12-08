using Plant_Store.Data.Interfaces;
using Plant_Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Store.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly Cart cart;
        private readonly DataContext dataContext;

        public OrderRepository(Cart cart, DataContext dataContext)
        {
            this.cart = cart;
            this.dataContext = dataContext;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            dataContext.Order.Add(order);
            dataContext.SaveChanges();

            var items = cart.ShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    PlantId = el.Plant.PlantId,
                    OrderId = order.OrderId,
                    Price = el.Plant.Price
                };
                dataContext.OrderDetail.Add(orderDetail);
            }
            dataContext.SaveChanges();
        }
    }
}
