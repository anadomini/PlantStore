using Microsoft.AspNetCore.Mvc;
using Plant_Store.Data.Interfaces;
using Plant_Store.Data.Models;

namespace Plant_Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart cart;
        private readonly IOrder orders;

        public OrderController(Cart cart, IOrder orders)
        {
            this.cart = cart;
            this.orders = orders;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            cart.ShopItems = cart.GetCartItems();

            if(cart.ShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You haven't bought anything yet :(");
            }

            if (ModelState.IsValid)
            {
                orders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete ()
        {
            ViewBag.Message = "Your order is successfully processed :)";
            return View();
        }
    }
}
