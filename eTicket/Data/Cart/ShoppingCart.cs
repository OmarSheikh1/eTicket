using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Cart
{
    public class ShoppingCart
    {
        private AppDbContext _apDbContext { get; }
        public int ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext appDbContext)
        {
            _apDbContext = appDbContext;
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _apDbContext.ShoppingCartItems.FirstOrDefault(n => n.ShoppingCartId == ShoppingCartId
            && n.Movie.Id == movie.Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _apDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _apDbContext.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _apDbContext.ShoppingCartItems.FirstOrDefault(n => n.ShoppingCartId == ShoppingCartId
            && n.Movie.Id == movie.Id);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _apDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }                
            }
            _apDbContext.SaveChanges();

        }
        
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _apDbContext.ShoppingCartItems.Where(n => n.Id ==
            ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _apDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
                                                .Select(n => n.Movie.Price * n.Amount).Sum();
    }
}
