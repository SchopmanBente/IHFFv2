using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;
using ProjectIHFFv2.Models.Repositories;

namespace ProjectIHFFv2.Controllers
{
    public class WishlistController : Controller
    {
        ICartRepository cartRepository = new CartRepository();
        IWishlistRepository wishlistRepository = new WishlistRepository();
        iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public ActionResult Index(bool? isToevoegenGelukt) //bool? omdat deze link ook direct aangeroepen kan worden, deze exception is opgevangen.
        {
            List<WishlistItem> alleItems = wishlistRepository.MakeWishlist(HaalWishlistSessieOp());
            if (isToevoegenGelukt == true) //Check of het toevoegen is gelukt 
            {
                TempData["isToevoegenGelukt"] = "true"; //Tempdata is nu en in de methode waarin deze gereturnt wordt nog bruikbaar, in dit geval is dat wishlistView
            }
            else if (isToevoegenGelukt == false)
            {
                TempData["isToevoegenGelukt"] = "false";
            }
            return View(alleItems);
        }

        
        public ActionResult Delete(int id)
        {
            wishlistRepository.RemoveFromWishlist(id , HaalWishlistSessieOp());
            return RedirectToAction("Index"); 
        }

        public ActionResult AddToCart()
        {
            List<ShoppingCartItem> cartSession = HaalCartSessieOp();
            List<WishlistItem> wishlistSession = HaalWishlistSessieOp();
            foreach (WishlistItem item in wishlistSession)
            {
                Event toeTeVoegenEvent = ctx.Event.FirstOrDefault(x => x.EventId == item.EventId);
                cartRepository.AddEventToCart(toeTeVoegenEvent, item.aantal, cartSession);
            }
            return RedirectToAction("Index", "Cart");
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