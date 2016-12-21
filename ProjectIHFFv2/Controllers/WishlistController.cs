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
        WishlistRepository ctx = new WishlistRepository();

        public ActionResult Index()
        {
            //Session["wishlist"] = new List<WishlistItem>(); //session is aangemaakt als 'wishlist'.
            List<WishlistItem> sessionItems = HaalWishlistSessieOp();
            List<WishlistItem> alleItems = ctx.MakeWishlist(sessionItems);
            return View(alleItems);
        }


        private List<WishlistItem> HaalWishlistSessieOp()
        {
            if (Session["wishlist"] == null)
            {
                List<WishlistItem> items = new List<WishlistItem>();
                Session["wishlist"] = items;
                return items;
            }
            else
            {
                var wishlist = Session["wishlist"] as List<WishlistItem>;
                List<WishlistItem> items = (List<WishlistItem>)wishlist;
                return items;
            }
        }
    }
}