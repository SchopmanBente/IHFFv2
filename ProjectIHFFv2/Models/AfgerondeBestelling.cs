using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIHFFv2.Models;
using ProjectIHFFv2.Models.Repositories;

namespace ProjectIHFFv2.Models
{
    
   public class AfgerondeBestelling
    {
        public Klant Klant { get; set; }
       
        public List<ShoppingCartItem> Events { get; set; }

        public string ophaalcode { get; set; }

        public AfgerondeBestelling()
        {

        }

        public AfgerondeBestelling(Klant Klant, List<ShoppingCartItem> Events)
        {
            this.Klant = Klant;
            this.Events = Events; 
        }

      
    }
}
