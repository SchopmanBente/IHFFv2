using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models; 

namespace ProjectIHFFv2.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantRepository resrep = new RestaurantRepository(); 
        // GET: Restaurant
        public ActionResult Bloemendaal()
        {
            IEnumerable<Event> resb = resrep.GetRestaurantsBloemendaal(); 

            return View(resb);
        }
    }
}