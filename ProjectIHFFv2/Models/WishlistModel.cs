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
        public int xCoordinaat { get; set; }
        public int yCoordinaat { get; set; }
        public int colspan { get; set; }
    }
}