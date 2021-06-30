using ShoppingCartApp.Models;

namespace ShoppingCartApp.Repository
{
    public interface IShoppingCartRepository
    {
        int CreateShoppingCart();

        void AddCartItem(int shoppingCartId, Item item);

        double GetShoppingCartTotal(int shoppingCartId);

        Offer GetOfferByCode(string code);
    }
}