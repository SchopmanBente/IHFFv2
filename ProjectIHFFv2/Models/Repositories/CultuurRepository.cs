using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class CultuurRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public IEnumerable<Cultuuritem> GetRandomCultuurItems()
        {
            List<Cultuuritem> items = new List<Cultuuritem>();
            List<int> randomNummers = new List<int>();
            //Bepaal random positie
            Random random = new Random();
            
            //Haal 5 x een random cultuuritem op
            do
            {
                int optie = random.Next(0, 19);
                if (!randomNummers.Exists(c => c == optie))
                {
                    Cultuuritem item = ctx.Cultuuritem.FirstOrDefault(c => c.id == optie);
                    items.Add(item);
                }

            } while (items.Count < 5);

            return items.AsEnumerable();

        }

    }
}