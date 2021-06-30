using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _itemStock;
        
        public ItemRepository()
        {
            _itemStock = GetAllItems;
        }

        public Item GetItemByCode(string code)
        {
            if (_itemStock.Any(x => x.ItemCode == code))
            {
                return _itemStock.FirstOrDefault(x => x.ItemCode == code);
            }

            return null;
        }

        public double GetItemPrice(string code)
        {
            if (_itemStock.Any(x => x.ItemCode == code))
            {
                return _itemStock.FirstOrDefault(x => x.ItemCode == code).Price;
            }

            return 0;
        }

        private static List<Item> GetAllItems => new List<Item>()
            {
                new Item() { ItemCode = "apple", Name = "Apple", Price = 0.60},
                new Item() { ItemCode = "orange", Name = "Orange", Price = 0.25}
            };

    }
}
    