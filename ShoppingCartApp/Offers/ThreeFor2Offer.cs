using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Offers
{
    public class ThreeFor2Offer : IOffer
    {
        public double ApplyOffers(List<CartItem> items, Offer offer)
        {
            double discountPrice = 0;
            foreach (var offerItem in offer.ItemCodes)
            {
                var item = items.FirstOrDefault(item => item.ItemCode == offerItem);
                if (item != null)
                {
                    var discountedQuantity = Math.Round((double)(item.Quantity % 2));
                    discountPrice += item.Price * discountedQuantity;
                }
            }

            return discountPrice;
        }
    }
}
