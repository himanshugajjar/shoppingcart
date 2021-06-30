using ShoppingCartApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repository
{
    public class ItemRepository
    {
        public double GetItemPrice(string code)
        {
            var listItems = All;
            if(listItems.Any(x => x.Code == code))
                return listItems.FirstOrDefault(x => x.Code == code).Price;
            return 0;
        }
        private static List<Item> All => new List<Item>()
            {
                new Item() { Code = "apple", Name = "Apple", Price = 0.60},
                new Item() { Code = "orange", Name = "Orange", Price = 0.25}
            };

        public static List<Item> Items { get; set; }
    }
}
    