using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Controllers
{
    public class FilmController : Controller
    {
        //
        // GET: /Film/
        private PresentationViews presentation = new PresentationViews();

        public ActionResult Index()
        {
            return RedirectToAction("Wednesday");
        }
        //Wednesday - Sunday(): Haal alle films voor een dag op
        public ActionResult Wednesday()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 11, 00, 00, 00));
            return View(films);
        }


        public ActionResult Thursday()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 12, 00, 00, 00));
            return View(films);
        }


        public ActionResult Friday()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 13, 00, 00, 00));
            return View(films);
        }


        public ActionResult Saturday()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 14, 00, 00, 00));
            return View(films);
        }

        public ActionResult Sunday()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 15, 00, 00, 00));
            return View(films);
        }


        //Haal de detailpagina van specials op
        public ActionResult ViewDetails(int? id)
        {
            //Kijk of de id bestaat en of deze in de scope van de films valt
            if (id != null && id >= 1 && id <= 50)
            {
                int eventId = (int)id;
                FilmDetailPresentationModel filmDetail = presentation.GetFilmDetails(eventId);
                return View(filmDetail);
            }
            //Anders redirect naar eerste overzicht        
           return RedirectToAction("Wednesday", "Film");
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
                            //Haal de list op uit de sessie
                            List<WishlistItem> items = HaalWishlistSessieOp();
                            //Voeg dit item ook toe aan de sessie
                            presentation.AddToWishlist(aantal, eventid, items);
                            return RedirectToAction("Index", "Wishlist");
                        case "Add to cart":
                            //Haal de list<ShoppingCartItems> op uit de sessie
                            List<ShoppingCartItem> cartItems = HaalCartSessieOp();
                            //Voeg het item toe aan de sessie
                            presentation.AddToCart(aantal, eventid, cartItems);
                            return RedirectToAction("Index", "Cart");
                    }
      
                }
               else
               {
                   FilmDetailPresentationModel filmDetail = presentation.GetFilmDetails(eventid);
                   return View(filmDetail);
               }
             
            }
            FilmDetailPresentationModel filmD = presentation.GetFilmDetails(eventid);
            return View(filmD);
        }

        private List<ShoppingCartItem> HaalCartSessieOp()
        {
            //Bekijk of de sessie bestaat
            if (Session["cart"] == null)
            {
                //Maak een sessie aan met een lege lijst ShoppingCartItems
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                Session["cart"] = items;
                return items;
            }
            else
            {
                //Haal de informatie op uit de bestaande sessie
                var cart = Session["cart"] as List<ShoppingCartItem>;
                List<ShoppingCartItem> items = (List<ShoppingCartItem>)cart;
                return items;
            }
        }

        private List<WishlistItem> HaalWishlistSessieOp()
        {
            //Bekijk of de sessie bestaat
            if (Session["wishlist"] == null)
            {
                //maak de sessie aan
                List<WishlistItem> items = new List<WishlistItem>();
                Session["wishlist"] = items;
                return items;
            }
            else
            {
                //Haal de informatie uit de bestaande sessie op
                var wishlist = Session["wishlist"] as List<WishlistItem>;
                List<WishlistItem> items = (List<WishlistItem>)wishlist;
                return items;
            }
        }

        }
    }
