using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
   public class RestaurantOverviewPresentationModel
    {
        public Event Event { get;set; }

        public RestaurantOverviewPresentationModel(Event Event)
        {
            this.Event = Event; 
        }
    }
}
