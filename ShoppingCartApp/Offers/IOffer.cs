using ShoppingCartApp.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Offers
{
    public interface IOffer
    {
        double ApplyOffers(List<CartItem> items, Offer offer);
    }
}
