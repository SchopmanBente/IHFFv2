using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class CartRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public void AddEventToCart(Event gebeuren, int aantalPersonen, List<ShoppingCartItem> cartItems)
        {
            double prijs = ((double)gebeuren.prijs * aantalPersonen);
            ShoppingCartItem item = new ShoppingCartItem(gebeuren, aantalPersonen, prijs);
            cartItems.Add(item);
        }
    }
}