using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectIHFFv2.Models.Repositories;

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

        public IEnumerable<Film> GetRandomFilms()
        {
            Random rnd = new Random();
            List<int> rndFilmid = new List<int>();
            List<Film> films = new List<Film>();


            while (films.Count < 5)
            {
                int optie = rnd.Next(0, 24);

                if (!rndFilmid.Contains(optie))
                {
                    rndFilmid.Add(optie);

                    Film film = ctx.Film.SingleOrDefault(f => f.EventId == optie);
                    if (film != null && !films.Any(f => f.naam.Contains(film.naam)))
                        films.Add(film);
                }
            }


            return films.AsEnumerable();
        }

        public IEnumerable<Cultuuritem> GetMonuments()
        {
            //Haal alle cultuuritems op waarvan de soort monument is.
            IQueryable<Cultuuritem> monuments = ctx.Cultuuritem.Where(c => c.soort == "Monument");
            return monuments;
        }

        public IEnumerable<Cultuuritem> GetMuseums()
        {
            //Haal alle cultuuritems op waarvan de soort museum is.
            IQueryable<Cultuuritem> museums = ctx.Cultuuritem.Where(c => c.soort == "Museum");
            return museums;
        }

        public IEnumerable<Cultuuritem> GetMusics()
        {
            //Haal alle cultuuritems op waarvan de soort music is.
            IQueryable<Cultuuritem> musics = ctx.Cultuuritem.Where(c => c.soort == "Music");
            return musics;
        }

        public Cultuuritem GetCultuurItem(int? id) //Nullable int voor wanneer de pagina zonder id wordt geopend.
        {
            //Haal alle cultuuritems op waarvan de id dit nummer is.
            Cultuuritem cultuurItem = ctx.Cultuuritem.FirstOrDefault(x => x.id == id);
            return cultuurItem;
        }

    }
}