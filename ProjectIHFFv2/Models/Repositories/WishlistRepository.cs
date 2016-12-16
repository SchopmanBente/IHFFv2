using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models.Repositories
{
    public class WishlistRepository
    {
        //Hier session of cookies pakken wanneer de 'database' aangeroepen wordt.
        public List<WishlistModel> GetWishlist()
        {
            List<WishlistModel> wishlist = new List<WishlistModel>();
            //pak uit de session of cookie alle dingen die aan die hieraan zijn toegevoegd.
            return wishlist;
        }

        public void AddToWishlist(WishlistModel item)
        {
            //voeg item toe aan session die een lijst van wishlistmodels bevat.
        }

        public void RemoveFromWishlist(WishlistModel item)
        {
            //verwijder de wishlistmodel uit de wishlistlijst.
        }

        public void EditWishtlist(WishlistModel item)
        {

        }

    }
}