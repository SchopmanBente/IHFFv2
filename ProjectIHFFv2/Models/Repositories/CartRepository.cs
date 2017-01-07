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
        // voor ophaalcode
        Random ran = new Random();
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

   
        public void AddKlant(Klant klant)
        {
            //voeg een klant die heeft betaald toe aan de db
            ctx.Klant.Add(klant);
            ctx.SaveChanges();

        }

        public int GetKlantId(Klant kl)
        {
            Klant klant = ctx.Klant.SingleOrDefault(k => k.emailadres == kl.emailadres);

            return klant.id; 
        }

        public string GenerateOphaalCode()
        { 
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, 7)
                    .Select(x => input[ran.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

        public void AddReservering(int klantId)
        {
            Reservering reservering = new Reservering(klantId, GenerateOphaalCode(), true, false);
            ctx.Reservering.Add(reservering);
            ctx.SaveChanges(); 
        }
        public void KoppelKlantReservering(int klantId, Reservering reservering)
        { // maak nieuwe reservering in db met bijbehorende klant id

            ctx.Reservering.Add(reservering);
            ctx.SaveChanges(); 
        }

        public bool BestaandeKlant(string email)
        {
            bool bestaat = ctx.Klant.Any(k => k.emailadres.Equals(email));

            return bestaat; 
        }

   
    }
}