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
            //Bepaal prijs voor event
             double prijs;
            //Als Event is een special of een film
            if (gebeuren.type == 0 || gebeuren.type == 3)
            {
               prijs = ((double)gebeuren.prijs * aantalPersonen);
            }
             //Elk ander geval
            else
            {
                prijs = (double)gebeuren.prijs;
            }

             prijs =  (double)gebeuren.prijs;
            //Maak een nieuw shoppingcartitem
            ShoppingCartItem item = new ShoppingCartItem(gebeuren, aantalPersonen, prijs);
            List<ShoppingCartItem> itemsInCart = cartItems;
            //Als het item niet bestaat in de shoppingcart voeg toe.
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