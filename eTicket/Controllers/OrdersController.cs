using eTicket.Data.Cart;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class OrdersController : Controller
    {
        public IMovieService _movieService { get; }

        private ShoppingCart _shoppingCart;
        public OrdersController(IMovieService movieService,ShoppingCart shoppingCart )
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View();
        }
    }

    public interface IMovieService
    {
    }
}
