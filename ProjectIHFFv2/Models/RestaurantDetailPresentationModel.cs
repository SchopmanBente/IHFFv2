using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class RestaurantDetailPresentationModel
    {
        public List<Film> Films { get; set; }
        public Event Event { get; set; }
        public RestaurantDetailPresentationModel(List<Film> Films, Event Event)
        {
            this.Films = Films;
            this.Event = Event; 
        }
    }
}