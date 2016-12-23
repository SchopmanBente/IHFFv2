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
            List<ShoppingCartItem> itemsInCart = cartItems;
            if(!itemsInCart.Exists(i => i.Gebeurtenis.EventId == item.Gebeurtenis.EventId))
            {
                      cartItems.Add(item);
            }
      
        }

        public List<ShoppingCartItem> RemoveFromCart(int id, List<ShoppingCartItem> sessie)
        {
            ShoppingCartItem teVerwijderen = sessie.Single(i => i.Gebeurtenis.EventId == id);
            sessie.Remove(teVerwijderen);

            return sessie; 
        }



        public double GetTotaalPrijs(List <ShoppingCartItem> items)
        { 
            double totaalPrijs = 0; 

            foreach(ShoppingCartItem i in items)
            {
                totaalPrijs = totaalPrijs + i.Prijs; 
            }

            return totaalPrijs; 
        }

   

     
    }
}