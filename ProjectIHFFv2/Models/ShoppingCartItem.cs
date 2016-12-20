using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class ShoppingCartItem
    {
        public Event Gebeurtenis { get; set; }
        public int AantalPersonen { get; set; }
        public double Prijs { get; set; }

        public ShoppingCartItem(){}

        public ShoppingCartItem(Event gebeuren, int aantal, double prijs)
        {
            this.Gebeurtenis = gebeuren;
            this.AantalPersonen = aantal;
            this.Prijs = prijs;
        }

    }
}