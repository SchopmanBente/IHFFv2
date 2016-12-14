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


        public IEnumerable<Event> GetRestaurantsBloemendaal()
        {
            DateTime dag = new DateTime(2017, 1, 11);
            IEnumerable<Event> res = ctx.Event.Where(r => r.type == 2 && r.Locatie.plaats == "Bloemendaal");

            IEnumerable<Event> resU = res.DistinctBy(e => e.naam); 
           // IEnumerable<Event> resBl = ctx.Event.DistinctBy(r => r.naam) ; 
              
            return resU; 
             
        }

        public IEnumerable<Event> GetRestaurantsHaarlem()
        {
            DateTime dag = new DateTime(2017, 1, 11);
            IEnumerable<Event> res = ctx.Event.Where(r => r.type == 2 && r.Locatie.plaats == "Haarlem");

            IEnumerable<Event> resU = res.DistinctBy(e => e.naam);
            // IEnumerable<Event> resBl = ctx.Event.DistinctBy(r => r.naam) ; 

            return resU;

        }


    }
}
