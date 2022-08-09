using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eTicket.Data.Cart
{
    public class ShoppingCart
    {
        private AppDbContext _apDbContext { get; }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext appDbContext)
        {
            _apDbContext = appDbContext;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
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

        public async Task clearShoppingCartAsync()
        {
            var items = await _apDbContext.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _apDbContext.ShoppingCartItems.RemoveRange(items);
            await _apDbContext.SaveChangesAsync();

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _apDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId ==
            ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _apDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
                                                .Select(n => n.Movie.Price * n.Amount).Sum();
    }
}
