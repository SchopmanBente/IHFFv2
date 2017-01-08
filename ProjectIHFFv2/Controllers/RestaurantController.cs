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
            //haal alle restaurants adhv locatie op
            IEnumerable<RestaurantOverviewPresentationModel> resb = presentation.GetAllRestaurantsByLocation("Bloemendaal");

            return View(resb);
        }

        public ActionResult Haarlem()
        {
            //haal alle restaurants adhv locatie op
            IEnumerable<RestaurantOverviewPresentationModel> resh = presentation.GetAllRestaurantsByLocation("Haarlem");

            return View(resh);
        }


        public ActionResult DetailPagina(int id)
        {
            
            //Vul detailpagina met juiste gegevens adhv id van geselecteerde restaurant
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
                            bool isGelukt = presentation.AddToWishlist(qty, eventid, items);
                            return RedirectToAction("Index", "Wishlist", new { isToevoegenGelukt = isGelukt});
                        case "Add to cart":
                            List<ShoppingCartItem> cartItems = HaalCartSessieOp();
                            presentation.AddToCart(qty, eventid, cartItems);

                            return RedirectToAction("Index", "Cart");
                        default:
                            return View();
                    }
                }

                else
                { // zorgt dat er een error wordt gegeven als er geen correct aantal is geselecteerd
                    ModelState.AddModelError("NoAmount", "No amount selected.");
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
                //Maak nieuwe sessie aan als deze nog niet bestaat
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                Session["cart"] = items;
                return items;
            }
            else
            { // haal sessie op als deze all bestaat (!= null)
                var cart = Session["cart"] as List<ShoppingCartItem>;
                List<ShoppingCartItem> items = (List<ShoppingCartItem>)cart;
                return items;
            }
        }
        private List<WishlistItem> HaalWishlistSessieOp()
        {
            if (Session["wishlist"] == null)
            {
                //zie bovenstaande methode
                List<WishlistItem> items = new List<WishlistItem>();
                Session["wishlist"] = items;
                return items;
            }
            else
            {   //zie bovenstaande methode
                var wishlist = Session["wishlist"] as List<WishlistItem>;
                List<WishlistItem> items = (List<WishlistItem>)wishlist;
                return items;
            }
        }
    }
}