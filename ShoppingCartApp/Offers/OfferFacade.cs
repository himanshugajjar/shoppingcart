using ShoppingCartApp.Models;
using ShoppingCartApp.Repository;
using System.Collections.Generic;

namespace ShoppingCartApp.Offers
{
    public class OfferFacade
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OfferFacade(ShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }


        public double ApplyDiscountOffers(string offerCode, List<CartItem> cartItems)
        {
            double discountedPrice = 0;
            var offer = _shoppingCartRepository.GetOfferByCode(offerCode);

            if (offer == null)
            {
                return discountedPrice;
            }

            switch (offer.Code)
            {
                case CommonConstants.OfferBuy1Get1Apple:
                    discountedPrice = new Buy1Get1Offer().ApplyOffers(cartItems, offer);
                    break;
                case CommonConstants.Offer3For2:
                    discountedPrice = new ThreeFor2Offer().ApplyOffers(cartItems, offer);
                    break;
            }

            return discountedPrice;
        }

    }
}
