﻿using ProjectIHFFv2.Models.Repositories;
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

            prijs = (double)gebeuren.prijs;
            //Maak een nieuw shoppingcartitem
            ShoppingCartItem item = new ShoppingCartItem(gebeuren, aantalPersonen, prijs);
            List<ShoppingCartItem> itemsInCart = cartItems;
            //Als het item niet bestaat in de shoppingcart voeg toe.
            if (!itemsInCart.Exists(i => i.Gebeurtenis.EventId == item.Gebeurtenis.EventId))
            {
                cartItems.Add(item);
            }
            else
            {
                int index = cartItems.FindIndex(i => i.Gebeurtenis.EventId == item.Gebeurtenis.EventId);
                cartItems[index] = item;
            }

        }

        public List<ShoppingCartItem> RemoveFromCart(int id, List<ShoppingCartItem> sessie)
        { //bepaal te verwijderen event adhv eventid
            ShoppingCartItem teVerwijderen = sessie.Single(i => i.Gebeurtenis.EventId == id);

            //verwijder event
            sessie.Remove(teVerwijderen);

            return sessie;
        }



        public double GetTotaalPrijs(List<ShoppingCartItem> items)
        {
            double totaalPrijs = 0;

            foreach (ShoppingCartItem i in items)
            {  //zorgt dat als het event een restaurant niet elke persoon reserveringskosten hoeft te betalen
                if (i.Gebeurtenis.type == 2)
                    totaalPrijs = totaalPrijs + i.Prijs;
                //zorgt dat als het event geen restaurant is er voor elke persoon moet worden betaald. 
                else
                    totaalPrijs = totaalPrijs + (i.Prijs * i.AantalPersonen);
            }

            return totaalPrijs;
        }

        public AfgerondeBestelling CheckoutToBestelling(CheckoutModel checkout)
        {
            Klant klant = new Klant(checkout.Email, checkout.VoorNaam, checkout.AchterNaam, checkout.TelefoonNummer);
            List<ShoppingCartItem> lijst = new List<ShoppingCartItem>();
            foreach (ShoppingCartItem e in checkout.Reserveringen.Items)
            {
                lijst.Add(e);
            }

            //Order lijst bij datum 
            lijst.OrderBy(c => c.Gebeurtenis.begin_datumtijd);


            AfgerondeBestelling Bestelling = new AfgerondeBestelling(klant, lijst);




            return Bestelling;
        }


        public void AddKlant(Klant klant)
        {
            //voeg een klant die heeft betaald toe aan de db
            ctx.Klant.Add(klant);
            ctx.SaveChanges();

        }

        public int GetKlantId(string email)
        {
            Klant klant = ctx.Klant.SingleOrDefault(k => k.emailadres == email);

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
        public void KoppelKlantReservering(int klantId, AfgerondeBestelling Bestelling)
        { // Maak voor elk bestelde event een Klant-reservering in de database met reserveringId van de klant

            int reserveringsId = GetReserveringId(klantId);

                foreach (ShoppingCartItem i in Bestelling.Events)
                {
                    Klant_reservering kl = new Klant_reservering(reserveringsId, i.Gebeurtenis.EventId, i.Gebeurtenis.prijs, i.AantalPersonen);
                    ctx.Klant_reservering.Add(kl);

                    ctx.SaveChanges();
                }
            

           
        }

        public bool BestaandeKlant(string email)
        {   //kijk of klant record al bestaat adhv email adres
            bool bestaat = ctx.Klant.Any(k => k.emailadres.Equals(email));

            return bestaat;
        }

        public int GetReserveringId(int klantId)
        {
            //haal laatste reservering uit db op adhv klantid
            Reservering res = ctx.Reservering.OrderByDescending(r => r.besteldatum).FirstOrDefault(r => r.klantid == klantId);

            return res.id;
        }

        public string GetOphaalCode(int reserveringId)
        {
            //haal de gegenereerde ophaalcode op uit db adhv reserveringid
            string code = ctx.Reservering.Where(c => c.id == reserveringId).Select(c => c.ophaalcode).SingleOrDefault();

            return code;
        }

        //     VERANDER DE CAPACITEIT IN DE DB
        public bool ChangeCapacity(AfgerondeBestelling bestelling)
        {
            bool Changegelukt = false;

            //verander voor elke reservering de capaciteit in de database
            foreach (ShoppingCartItem e in bestelling.Events)
            {
                //zet gelukt weer op false voor volgende item; 
                Changegelukt = false; 
                Locatie eventLocatie = e.Gebeurtenis.Locatie;
                //haal huidige capaciteit op
                int huidigecapaciteit = Convert.ToInt32(ctx.Locatie.Where(c => c.id == e.Gebeurtenis.Locatie.id).Select(c => c.capaciteit).SingleOrDefault());
                //als huidige capaciteit groter of gelijk aan gewenste
                if (huidigecapaciteit >= e.AantalPersonen)
                {


                    try
                    {
                        //probeer capaciteit aan te passen
                        (from l in ctx.Locatie
                         where l.id.Equals(eventLocatie.id)
                         select l)
                            .ToList()
                            .ForEach(c => c.capaciteit = c.capaciteit - e.AantalPersonen);

                        ctx.SaveChanges();


                        Changegelukt = true;
                    }
                    catch { }
                }
            }
            return Changegelukt;



        }

    }
}