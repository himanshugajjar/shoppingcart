using ShoppingCartApp.Models;

namespace ShoppingCartApp.Repository
{
    public interface IItemRepository
    {
        double GetItemPrice(string code);

        Item GetItemByCode(string code);
    }
}
