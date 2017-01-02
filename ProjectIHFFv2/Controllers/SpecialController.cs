using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Controllers
{
    public class SpecialController : Controller
    {
        //
        // GET: /Special/
        private PresentationViews presentation = new PresentationViews();

        public ActionResult Index()
        {
            return RedirectToAction("Wednesday");
        }

        //Methode Wednesday() - Sunday(): Haal op basis van dag de specials op
        public ActionResult Wednesday()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 11, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Thursday()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 12, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Friday()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 13, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Saturday()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 14, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Sunday()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 15, 00, 00, 00));
            return View(specials);
        }
       

        public ActionResult ViewDetails(int? id)
        {
            //Onderzoek of de link een id meegekregen heeft die niet null is
            if (id != null && id >= 50 && id <= 60)
            {
                //Cast het id naar een int
                int eventId = (int)id;
                //Haal alle informatie voor specials op
                SpecialDetailPresentationModel special = presentation.GetSpecialDetails(eventId);
                return View(special);
            }

            return RedirectToAction("Friday", "Special");
        }

        [HttpPost]
        public ActionResult ViewDetails(int eventid, int? qty, string submit)
        {
            if (ModelState.IsValid)
            {
                if (qty > 0)
                {
                    int aantal = (int)qty;
                    //Onderzoek welke knop is ingedrukt
                    switch (submit)
                    {
                        case "Add to wishlist":
                            //Haal alle items die in de wishlist staan op
                            List<WishlistItem> items = HaalWishlistSessieOp();
                            //Voeg toe aan wishlist
                            presentation.AddToWishlist(aantal, eventid, items);
                            return RedirectToAction("Index", "Wishlist");
                        case "Add to cart":
                            //Haal alle items die in de cart staan op
                            List<ShoppingCartItem> cartItems = HaalCartSessieOp();
                            //Voeg toe aan de cart
                            presentation.AddToCart(aantal, eventid, cartItems);
                            return RedirectToAction("Index", "Cart");
                        
                    }

                }
                else
                {
                    SpecialDetailPresentationModel special = presentation.GetSpecialDetails(eventid);
                    return View(special);
                }
                
            }
            SpecialDetailPresentationModel s = presentation.GetSpecialDetails(eventid);
            return View(s);
        }

        private List<ShoppingCartItem> HaalCartSessieOp()
        {
            //Onderzoek of de cartsessie items bevat
            if (Session["cart"] == null)
            {
                //Maak een nieuwe list items aan
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                Session["cart"] = items;
                return items;
            }
            else
            {
                //Haal alle shoppingcartitems op
                var cart = Session["cart"] as List<ShoppingCartItem>;
                List<ShoppingCartItem> items = (List<ShoppingCartItem>)cart;
                return items;
            }
        }

        private List<WishlistItem> HaalWishlistSessieOp()
        {
            //Onderzoek of er een wishlistsessie bestaat
            if (Session["wishlist"] == null)
            {
                //Maak een nieuwe list aan
                List<WishlistItem> items = new List<WishlistItem>();
                //Vul de sessie met de lijst
                Session["wishlist"] = items;
                return items;
            }
            else
            {
                //Haal de huidige items op
                var wishlist = Session["wishlist"] as List<WishlistItem>;
                List<WishlistItem> items = (List<WishlistItem>)wishlist;
                return items;
            }
        }

	}
}