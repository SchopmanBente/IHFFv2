using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
    public class RestaurantOverviewPresentationModel
    {
        public Event Event { get; set; }
        public string Beschrijving
        {
            get
            {
                if (Event.beschrijving.Length >= 110)
                    return Event.beschrijving.Substring(0, 110) + "...";

                else
                    return Event.beschrijving; 
            }
        }




        public RestaurantOverviewPresentationModel(Event Event)
        {
            this.Event = Event;

        }
    }
}
