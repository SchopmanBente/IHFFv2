using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectIHFFv2.Models
{
    public class RestaurantDetailPresentationModel
    {
        public List<Film> Films { get; set; }
       
        public Event Event { get; set; }
        public List<Event> Maaltijden { get; set; }
        
    

        public int AantalPersonen { get; set; }
        public RestaurantDetailPresentationModel(List<Film> Films, Event Event, List<Event> Maaltijden)
        {
            this.Films = Films;
            this.Event = Event;
            this.Maaltijden = Maaltijden;
        }
    }
}