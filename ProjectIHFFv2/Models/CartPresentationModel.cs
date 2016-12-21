using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
   public class CartPresentationModel
    {
        public List<ShoppingCartItem> Items { get; set; }
        public double TotaalPrijs { get; set; }
        public CartPresentationModel()
        {

        }

        public CartPresentationModel(List<ShoppingCartItem> lijst, double TotaalPrijs)
        {
            Items = lijst;
            this.TotaalPrijs = TotaalPrijs; 
        }
    }
}
