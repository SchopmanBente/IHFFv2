using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class FilmRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public IEnumerable<Film> GetAllForDay(DateTime dag)
        {
            IQueryable<Film> filmsDay = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Day == dag.Day).OrderBy(x => x.Event.begin_datumtijd);
            return filmsDay;
        }

        public IEnumerable<Film> GetAllEventsForDetail(string naam)
        {
            IQueryable<Film> voorstellingen = ctx.Film.Where(x => x.Event.type == 0 && x.Event.naam == naam);
            return voorstellingen;
        }

        public Film GetById(int id)
        {
            Film film = ctx.Film.FirstOrDefault(x => x.Event.EventId == id);
            return film;
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








    }
}