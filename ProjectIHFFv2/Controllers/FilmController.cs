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

        public ActionResult ViewDetails(int? id)
        {
            if (id != null)
            {
                int eventId = (int)id;
                FilmDetailPresentationModel filmDetail = presentation.GetFilmDetails(eventId);
                return View(filmDetail);
            }
                    
           return RedirectToAction("Wednesday", "Film");
        }

        [HttpPost]
        public ActionResult ViewDetails(int eventid, int qty, string submit)
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

                return View();
            }
            return View();
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
