using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Controllers
{
    public class WishlistController : Controller
    {
        public ActionResult Index()
        {
            Session["wishlist"] = new List<WishlistItem>(); //session is aangemaakt als 'wishlist'.
            return View();
        }
    }
}