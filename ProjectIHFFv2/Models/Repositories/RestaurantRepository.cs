using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
    

    public class RestaurantRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();


        public IEnumerable<Event> GetRestaurantsByPlaatsnaam(string plaatsnaam)
        {   //dag word gezet op de eerste dag van het festival
            DateTime dag = new DateTime(2017, 1, 11);

            //haal alle events op adhv plaatsnaam
            IEnumerable<Event> res = ctx.Event.Where(r => r.type == 2 && r.Locatie.plaats == plaatsnaam);

            //Maak opgehaalde events uniek zodat er een unieke lijst van events wordt weergeven
            IEnumerable<Event> resU = res.DistinctBy(e => e.naam); 
           // IEnumerable<Event> resBl = ctx.Event.DistinctBy(r => r.naam) ; 
              
            return resU; 
             
        }

        public Event GetRestaurantByid(int? id)
        {
            Event restaurant = ctx.Event.FirstOrDefault(r => r.EventId == id);

            return restaurant; 
        }

        public IEnumerable<Event> GetRandomRestaurants()
        {
            List<Event> items = new List<Event>();
            List<int> randomNummers = new List<int>();
            //Bepaal random positie
            Random random = new Random();

            //Haal 5 x een random cultuuritem op
            do
            {
                int optie = random.Next(61,70);
                if (!randomNummers.Contains(optie))
                {
                    //Voeg nummer toe aan lijst
                    randomNummers.Add(optie);
                    //Haal het item met het id op
                    Event restaurant = ctx.Event.FirstOrDefault(r => r.EventId == optie);
                    //Als item ongelijk aan null voeg toe aan items
                    if (restaurant != null && !items.Exists(r => r.naam == restaurant.naam))
                        items.Add(restaurant);
                }

            } while (items.Count < 5);

            return items.AsEnumerable();
        }

        public IEnumerable<Event> GetAllMaaltijdenForDetail(string naam)
        {
            //haal alle mogelijke eet tijden op om te weergeven in detailpagina
            IQueryable<Event> maaltijden = ctx.Event.Where(r => r.naam == naam).OrderBy(e => e.begin_datumtijd);

            return maaltijden; 
        }

    }
}
