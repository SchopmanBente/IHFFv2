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
        {
            DateTime dag = new DateTime(2017, 1, 11);
            IEnumerable<Event> res = ctx.Event.Where(r => r.type == 2 && r.Locatie.plaats == plaatsnaam);

            IEnumerable<Event> resU = res.DistinctBy(e => e.naam); 
           // IEnumerable<Event> resBl = ctx.Event.DistinctBy(r => r.naam) ; 
              
            return resU; 
             
        }

        public Event GetRestaurantByid(int id)
        {
            Event restaurant = ctx.Event.FirstOrDefault(r => r.EventId == id);

            return restaurant; 
        }


    }
}
