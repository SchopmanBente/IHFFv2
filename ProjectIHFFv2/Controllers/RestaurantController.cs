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
        private PresentationViews presentation = new PresentationViews();
        // GET: Restaurant
        public ActionResult Bloemendaal()
        {
            IEnumerable<RestaurantOverviewPresentationModel> resb = presentation.GetAllRestaurantsByLocation("Bloemendaal");

            return View(resb);
        }

        public ActionResult Haarlem()
        {
            IEnumerable<RestaurantOverviewPresentationModel> resh = presentation.GetAllRestaurantsByLocation("Haarlem");

            return View(resh);
        }


        public ActionResult DetailPagina(int id)
        {
            
                RestaurantDetailPresentationModel restaurant = presentation.GetRestaurantDetails(id);

                return View(restaurant);
           
        }
    }
}