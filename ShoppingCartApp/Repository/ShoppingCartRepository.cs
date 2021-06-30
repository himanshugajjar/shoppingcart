using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly Dictionary<int, List<CartItem>> _listShoppingCart = new Dictionary<int, List<CartItem>>();
        private readonly List<Offer> _offers  = new List<Offer>();

        public ShoppingCartRepository()
        {
            _offers = AllOffer;
        }

        public int CreateShoppingCart()
        {
            _listShoppingCart.Add(_listShoppingCart.Count + 1, new List<CartItem>());

            return _listShoppingCart.Count;
        }

        public void AddCartItem(int shoppingCartId, Item item)
        {
            var shoppingCart = GetShoppingCartById(shoppingCartId);

            if (shoppingCart == null) return;

            if (shoppingCart.Any(x => x.ItemCode == item.ItemCode))
            {
                var cartItem = shoppingCart.FirstOrDefault(x => x.ItemCode == item.ItemCode);
                cartItem.Quantity += 1;
                cartItem.Total = cartItem.Quantity * item.Price;
            }
            else
            {
                shoppingCart.Add(new CartItem()
                {
                    ItemCode = item.ItemCode,
                    Price = item.Price,
                    Quantity = 1,
                    Total = item.Price
                });
            }
        }

        public List<CartItem> GetShoppingCartById(int shoppingCartId)
        {
            if (!_listShoppingCart.ContainsKey(shoppingCartId))
            {
                //log error
                var message = $"Shopping Cart not found  with id : {shoppingCartId}";
                Console.WriteLine(message);

                throw new InvalidOperationException(message);
            }

            return _listShoppingCart[shoppingCartId];
        }

        public double GetShoppingCartTotal(int shoppingCartId)
        {
            double total = 0;

            foreach(var item in _listShoppingCart[shoppingCartId])
            {
                total += item.Total;
            }

            return Math.Round(total, 2);
        }

        public Offer GetOfferByCode(string offerCode)
        {
            return _offers.FirstOrDefault(x => x.Code == offerCode);
        }

        private static List<Offer> AllOffer => new List<Offer>()
            {
                new Offer() { Id=123, Code = CommonConstants.OfferBuy1Get1Apple, Description = "Buy 1 Get 1 Apple", ItemCodes = new string[] {"apple"} },
                new Offer() { Id=456, Code = CommonConstants.Offer3For2, Description = "3 For Price 2", ItemCodes = new string[] {"orange"} }
            };

    }
}
