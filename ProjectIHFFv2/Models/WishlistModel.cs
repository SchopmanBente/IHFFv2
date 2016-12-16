using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class WishlistItem
    {
        public int EventId { get; set; }
        public string naam { get; set; }
        public DateTime? beginTijd { get; set; }
        public DateTime? eindTijd { get; set; }
        public double? prijs { get; set; }
        public int? locatieId { get; set; }
        public int type { get; set; }
        public double? aantal { get; set; }
        public DateTime EerstMogelijkeTijd { get; set; }


        public List<WishlistItem> MakeWishlist()
        {
            List<WishlistItem> wishlist = new List<WishlistItem>();
            DateTime standaardTijd = new DateTime(2017, 1, 11, 11, 00, 00);
            //MAAK EEN ARRAY MET COORDINATEN EN NEEM VAN DE COORDINAAT DE EERSTE WAARDE BOVENAAN EN DE EERSTE WAARDE LINKS. MAAK HIER EEN DATETIME VAN.
            int[,] tijdNavigatieArray = new int[20,20];

            //Van alle tijden die er zijn is er nu een tijd ingevuld. Bij de tabelcreatie wordt een if (!null) gebruikt.

            return wishlist;
        }
    }
}