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
               
                    for (int i = 0; i < Event.beschrijving.Length; i++)
                    { if (i > 80 && Event.beschrijving[Event.beschrijving.Length - 1] == ' ')
                    {
                        return Event.beschrijving.Substring(0, i) + "...";

                    }

                    else
                        return Event.beschrijving + "...";  
                    }
                   
               
            }
        }


        public RestaurantOverviewPresentationModel(Event Event)
        {
            this.Event = Event;

        }
    }
}
