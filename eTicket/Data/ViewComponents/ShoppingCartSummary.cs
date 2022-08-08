using eTicket.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        public ShoppingCart _shoppingCart { get; }
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count());
        }
    }
}
