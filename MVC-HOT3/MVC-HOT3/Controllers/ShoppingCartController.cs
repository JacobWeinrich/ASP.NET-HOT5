using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_HOT3.Models;

namespace MVC_HOT3.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly TechStoreContext _context;
        private readonly List<ShoppingCartItem> _cartItems;

        public ShoppingCartController(TechStoreContext ctx)
        {
            _context = ctx;
            _cartItems = new List<ShoppingCartItem>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            var phoneToAdd = _context.Phones.Find(id);

            var _cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingItem = _cartItems.FirstOrDefault(item => item.Phone.PhoneID == id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cartItems.Add(new ShoppingCartItem
                {
                    Phone = phoneToAdd,
                    Quantity = 1
                });
            }

            HttpContext.Session.Set("Cart", _cartItems);
            TempData["message"] = "Item added to cart!";
            return RedirectToAction("List", "Products");
        }

        public IActionResult ViewCart()
        {
            var _cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartViewModel = new CartViewModel
            {
                CartItems = _cartItems,
                CartTotal = _cartItems.Sum(item => (decimal)item.Phone.PhonePrice! * item.Quantity),
                TotalQuantity = _cartItems.Sum(item => item.Quantity)
            };
            return View(cartViewModel);
        }

        public IActionResult RemoveItem(int id)
        {
            var _cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var ItemToRemove = _cartItems.FirstOrDefault(item => item.Phone.PhoneID == id);

            if (ItemToRemove != null)
            {
                if (ItemToRemove.Quantity > 1)
                {
                    ItemToRemove.Quantity--;
                }
                else
                {
                    _cartItems.Remove(ItemToRemove);
                }
            }
            HttpContext.Session.Set("Cart", _cartItems);
            return RedirectToAction("ViewCart", "ShoppingCart");
        }

        public IActionResult PurchaseItems()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            foreach (var item in cartItems)
            {
                var purchase = new Purchase
                {
                    PhoneID = item.Phone.PhoneID,
                    Quantity = item.Quantity,
                    PurchaseDate = DateTime.Now,
                    Total = (decimal)item.Phone.PhonePrice! * item.Quantity
                };
                _context.Purchases.Add(purchase);
            }
            _context.SaveChanges();
            HttpContext.Session.Remove("Cart");
            TempData["message"] = "Thank you for your purchase!";
            return RedirectToAction("List", "Products");
            
        }
    }
}
