using ShoppingCartApp.Offers;
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

            var itemRepository = new ItemRepository();
            var shoppingCartRepository = new ShoppingCartRepository();
            var cartId = shoppingCartRepository.CreateShoppingCart();

            foreach (var item in items.Split(","))
            {
                var shoppingItem = itemRepository.GetItemByCode(item.Trim().ToLower());

                if (shoppingItem != null)
                {
                    shoppingCartRepository.AddCartItem(cartId, shoppingItem);
                }
            }

            OfferFacade offerFacade = new OfferFacade(shoppingCartRepository);
            Console.WriteLine("Enter Offer Code ");
            string offerCode = Console.ReadLine();

            var cartItems = shoppingCartRepository.GetShoppingCartById(cartId);
            var cartAfterDiscount = offerFacade.ApplyDiscountOffers(offerCode, cartItems);

            foreach (var item in cartItems)
            {
                Console.WriteLine($"{item.ItemCode}\t{item.Quantity}\t{item.Price}\t{item.Total}");
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total Amount \t\t{shoppingCartRepository.GetShoppingCartTotal(cartId)}");
            Console.WriteLine($"Total Discount \t\t{cartAfterDiscount}");
            Console.WriteLine($"Total Paid Amount \t{(shoppingCartRepository.GetShoppingCartTotal(cartId) - cartAfterDiscount).ToString("F2")}");
        }
    }
}