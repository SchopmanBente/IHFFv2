using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class WishlistModel
    {
        public int EventId { get; set; }
        public string titel { get; set; }
        public DateTime beginTijd { get; set; }
        public DateTime eindTijd { get; set; }
        public int prijs { get; set; }
        public int locatieId { get; set; }
        public int type { get; set; }
        public int aantal { get; set; }
        public DateTime EerstMogelijkeTijd { get; set; }


        public List<WishlistModel> MakeWishlist()
        {
            List<WishlistModel> wishlist = new List<WishlistModel>();
            DateTime standaardTijd = new DateTime(2017, 1, 11, 11, 00, 00);
            int i = 0;
            //Geef een datetime waarde aan de tijd die bovenaan de tabel staat. Hier kan je mee vergelijken. Elke keer wanneer je nu naar een nieuwe rij gaat moet je de datum wijzigen!
            while(i < 24){
                WishlistModel bla = new WishlistModel();
                if (i % 2 == 0) {
                    bla.EerstMogelijkeTijd = EerstMogelijkeTijd.AddHours(i);
                } else {
                    bla.EerstMogelijkeTijd = EerstMogelijkeTijd.AddHours(i).AddMinutes(30);
                    i++;
                }
            }
            return wishlist;
        }
    }
}