using ProjectIHFFv2.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class CartRepository : ICartRepository
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
        { //bepaal te verwijderen event adhv eventid
            ShoppingCartItem teVerwijderen = sessie.Single(i => i.Gebeurtenis.EventId == id);

            //verwijder event
            sessie.Remove(teVerwijderen);

            return sessie; 
        }



        public double GetTotaalPrijs(List <ShoppingCartItem> items)
        { 
            double totaalPrijs = 0; 

            foreach(ShoppingCartItem i in items)
            {  //zorgt dat als het event een restaurant niet elke persoon reserveringskosten hoeft te betalen
                if(i.Gebeurtenis.type == 2)
                totaalPrijs = totaalPrijs + i.Prijs; 
               //zorgt dat als het event geen restaurant is er voor elke persoon moet worden betaald. 
                else
                totaalPrijs = totaalPrijs + (i.Prijs*i.AantalPersonen); 
            }

            return totaalPrijs; 
        }

   
        public void AddKlant(Bezoeker bezoeker)
        {
            //voeg een klant die heeft betaald toe aan de db
            ctx.Klant.Add(bezoeker);
            ctx.SaveChanges();

        }

        public void AddReservering(ReserveringModel reservering)
        { // voegt een reservering toe zodat capaciteit kan worden aangepast

            ctx.Reservering.Add(reservering);
            ctx.SaveChanges(); 
        }

        public bool BestaandeKlant(string email)
        {
            bool bestaat = ctx.Klant.Any(k => k.emailadres.Equals(email));

            return bestaat; 
        }

        public ReserveringModel CheckoutToReservation( Bezoeker bezoeker)
        {
            //combineer een klant met reservering MAAR HOE IN DE DB??????

            ReserveringModel res = new ReserveringModel(bezoeker.id, DateTime.Now, true, false);

            return res; 
        }
    }
}