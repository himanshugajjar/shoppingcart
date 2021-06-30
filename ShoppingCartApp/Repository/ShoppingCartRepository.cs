using ShoppingCartApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repository
{
    public class ShoppingCartRepository
    {
        public static List<ShoppingCart> listShoppingCart = new List<ShoppingCart>();
        public void AddCartItem(double price, string item)
        {
            if (listShoppingCart.Any(x => x.ItemCode == item.ToLower()))
            {
                var cartItem = listShoppingCart.FirstOrDefault(x => x.ItemCode == item.ToLower());
                cartItem.Quantity += 1;
                cartItem.Total = cartItem.Quantity * price;
            }
            else
            {
                listShoppingCart.Add(new ShoppingCart()
                {
                    ItemCode = item.ToLower(),
                    Price = price,
                    Quantity = 1,
                    Total = price
                });
            }
        }
        public double GetTotalPrice()
        {
            double total = 0;
            foreach(var item in listShoppingCart)
            {
                total += item.Total;
            }
            return Math.Round(total,2);
        }
    }
}
