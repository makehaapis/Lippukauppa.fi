using Lippukauppa.fi.Data.Cart;
using Lippukauppa.fi.Data.Services;
using Lippukauppa.fi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lippukauppa.fi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IEventsService eventsService, ShoppingCart shoppingCart)
        {
            _eventsService= eventsService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var item = await _eventsService.GetEventByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _eventsService.GetEventByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
