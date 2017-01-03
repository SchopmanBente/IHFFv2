using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Models.Repositories
{
    public interface ICartRepository
    {
        void AddEventToCart(Event gebeuren, int aantalPersonen, List<ShoppingCartItem> cartItems);

        List<ShoppingCartItem> RemoveFromCart(int id, List<ShoppingCartItem> sessie);

        double GetTotaalPrijs(List<ShoppingCartItem> items);

        void AddKlant(Bezoeker bezoeker);

        void AddReservering(ReserveringModel reservering);

        bool BestaandeKlant(string email); 
    }
}
