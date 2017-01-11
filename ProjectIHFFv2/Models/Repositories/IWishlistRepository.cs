using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Models.Repositories
{
    public interface IWishlistRepository
    {
        bool AddToWishlist(Event item, int aantal, List<WishlistItem> items);
        void RemoveFromWishlist(int id, List<WishlistItem> wishlistSession);
        List<WishlistItem> MakeWishlist(List<WishlistItem> meegekregenWishlist);
    }
}
