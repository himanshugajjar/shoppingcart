using ShoppingCartApp.Repository;
using System;
using System.Text.RegularExpressions;

namespace ShoppingCartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Specify List of Items ");
            string items = Console.ReadLine();

            string strRegex = @"(apple|orange)";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(items))
            {
                Console.WriteLine("Invalid shopping item");
                return;
            }

            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            ItemRepository itemRepository = new ItemRepository();
            foreach(var item in items.Split(","))
            {
                double price = itemRepository.GetItemPrice(item);
                shoppingCartRepository.AddCartItem(price, item);
            }

            foreach(var item in ShoppingCartRepository.listShoppingCart)
            {
                Console.WriteLine(item.ItemCode + " " + item.Quantity + " " + item.Price + " " + item.Total);
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Total Amount " + shoppingCartRepository.GetTotalPrice());
            Console.WriteLine("Total Paid Amount " + (shoppingCartRepository.GetTotalPrice()));
        }
    }
}