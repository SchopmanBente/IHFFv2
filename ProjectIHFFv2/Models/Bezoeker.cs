using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
  public  class Bezoeker : Klant
    {
        

        public Bezoeker()
        { }

        public Bezoeker(string voorNaam, string achterNaam, string email, string telefoonNummer)
        {
            voornaam = voorNaam;
            achternaam = achterNaam;
            this.emailadres = email;
            telefoonnummer = telefoonNummer;
        }
    }
}
