using Microsoft.AspNetCore.Mvc;
using Plant_Store.Data.Interfaces;
using Plant_Store.Data.Models;
using Plant_Store.ViewModels;
using System.Linq;

namespace Plant_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly IPlant plantRepository;
        private readonly Cart cart;

        public CartController(IPlant plantRepository, Cart cart)
        {
            this.plantRepository = plantRepository;
            this.cart = cart;
        }

        public ViewResult Index()
        {
            var items = cart.GetCartItems();
            cart.ShopItems = items;

            var obj = new CartViewModel
            {
                cart = cart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            if(User.Identity.IsAuthenticated)
                    {
                var item = plantRepository.Plants.FirstOrDefault(i => i.PlantId == id);
                if (item != null)
                {
                    cart.AddToCart(item);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
