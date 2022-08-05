using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public string Id { get; set; }

        public Movie Movie { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
