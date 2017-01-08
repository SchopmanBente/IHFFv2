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

        void AddKlant(Klant klant);

        string GenerateOphaalCode();

        int GetKlantId(string email); 

        bool BestaandeKlant(string email);

        void AddReservering(int klantId);

        void KoppelKlantReservering(int klantId, AfgerondeBestelling Bestelling);
        AfgerondeBestelling CheckoutToBestelling(CheckoutModel checkout);

        int GetReserveringId(int klantId);
        string GetOphaalCode(int reserveringId);
    }
}
