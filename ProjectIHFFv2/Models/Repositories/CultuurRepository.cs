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
                if (!randomNummers.Contains(optie))
                {
                    //Voeg nummer toe aan lijst
                    randomNummers.Add(optie);
                    //Haal het item met het id op
                    Cultuuritem item = ctx.Cultuuritem.FirstOrDefault(c => c.id == optie);
                    //Als item ongelijk aan null voeg toe aan items
                    if(item != null && !items.Exists(c => c.naam == item.naam))
                        items.Add(item);
                }

            } while (items.Count < 5);

            return items.AsEnumerable();

        }

        public IEnumerable<Cultuuritem> GetMonuments()
        {
            IQueryable<Cultuuritem> monuments = ctx.Cultuuritem.Where(c => c.soort == "Monument");
            return monuments;
        }

        public IEnumerable<Cultuuritem> GetMuseums()
        {
            IQueryable<Cultuuritem> museums = ctx.Cultuuritem.Where(c => c.soort == "Museum");
            return museums;
        }

        public IEnumerable<Cultuuritem> GetMusics()
        {
            IQueryable<Cultuuritem> musics = ctx.Cultuuritem.Where(c => c.soort == "Music");
            return musics;
        }

    }
}