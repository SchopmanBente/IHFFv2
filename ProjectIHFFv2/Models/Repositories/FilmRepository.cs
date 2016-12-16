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
            IQueryable<Film> filmsDay = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Value.Day == dag.Day).OrderBy(x => x.Event.begin_datumtijd);
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


    }
}