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

        [HttpPost]
        public ActionResult DetailPagina(int eventid, int qty, string submit)
        {
            if (ModelState.IsValid)
            {
                if (qty > 0)
                {
                    switch (submit)
                    {
                        case "Add to wishlist":
                            List<WishlistItem> items = HaalWishlistSessieOp();
                            presentation.AddToWishlist(qty, eventid, items);
                            return RedirectToAction("Index", "Wishlist");
                        case "Add to cart":
                            List<ShoppingCartItem> cartItems = HaalCartSessieOp();
                            presentation.AddToCart(qty, eventid, cartItems);

                            return RedirectToAction("Index", "Cart");
                        default:
                            return View();
                    }
                }

                else
                {
                    ModelState.AddModelError("NoAmount", "Selecteer het aantal personen.");
                    return View(presentation.GetRestaurantDetails(eventid)); 
                }
            }
            else
                return View("DetailPagina"); 
            
        }

        private List<ShoppingCartItem> HaalCartSessieOp()
        {
            if (Session["cart"] == null)
            {
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                Session["cart"] = items;
                return items;
            }
            else
            {
                var cart = Session["cart"] as List<ShoppingCartItem>;
                List<ShoppingCartItem> items = (List<ShoppingCartItem>)cart;
                return items;
            }
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