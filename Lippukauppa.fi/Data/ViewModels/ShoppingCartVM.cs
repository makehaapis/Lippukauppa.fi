using Lippukauppa.fi.Data.Cart;

namespace Lippukauppa.fi.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
        public string ShoppingCartTotalToString { get; set; }
    }
}
