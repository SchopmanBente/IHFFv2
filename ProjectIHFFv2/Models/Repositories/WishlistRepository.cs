using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Models.Repositories
{
    public class WishlistRepository : Controller //:controller zodat de session gebruikt kan worden.
    {
        //Hier session of cookies pakken wanneer de 'database' aangeroepen wordt.
        public List<WishlistItem> GetWishlist()
        {
            List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            //pak uit de session of cookie alle dingen die aan die hieraan zijn toegevoegd.
            return wishlist;
        }

        public void AddToWishlist(Event item, int aantal, DateTime tijd)
        {
            //voeg item toe aan session die een lijst van wishlistmodels bevat.
            WishlistItem wishlistItem = new WishlistItem();
            wishlistItem.aantal = aantal;
            wishlistItem.EerstMogelijkeTijd = tijd;
            wishlistItem.beginTijd = item.begin_datumtijd;
            wishlistItem.eindTijd = item.eind_datumtijd;
            wishlistItem.EventId = item.EventId;
            wishlistItem.locatieId = item.locatie_id;
            wishlistItem.naam = item.naam;
            wishlistItem.prijs = item.prijs * aantal;
            wishlistItem.type = item.type;
            List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            wishlist.Add(wishlistItem);
        }

        public void RemoveFromWishlist(WishlistItem item)
        {
            List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            foreach (WishlistItem wishlistItem in wishlist)
            {
                if (wishlistItem.EventId == item.EventId)
                {
                    wishlist.Remove(wishlistItem);
                }
            }
        }

        public void EditWishtlist(WishlistItem item)
        {

        }

    }
}