using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class FilmRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public IEnumerable<Film> GetAllForWednesday()
        {
            DateTime wednesday = new DateTime(2017, 1, 11, 00, 00, 00);
            IQueryable<Film> filmsWednesday = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Value.Day == wednesday.Day).OrderBy(x => x.Event.begin_datumtijd);
            return filmsWednesday;
        }

        public IEnumerable<Film> GetAllForThursday()
        {
            DateTime thursday = new DateTime(2017, 1, 12, 00, 00, 00);
            IQueryable<Film> filmsThursday = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Value.Day == thursday.Day).OrderBy(x => x.Event.begin_datumtijd);
            return filmsThursday;
        }

        public IEnumerable<Film> GetAllForFriday()
        {
            DateTime friday = new DateTime(2017, 1, 13, 00, 00, 00);
            IQueryable<Film> moviesFriday = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Value.Day == friday.Day).OrderBy(x => x.Event.begin_datumtijd);
            return moviesFriday;
        }

        public IEnumerable<Film> GetAllForSaturday()
        {
            DateTime saturday = new DateTime(2017, 1, 14, 00, 00, 00);
            IQueryable<Film> moviesSaterday = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Value.Day == saturday.Day).OrderBy(x => x.Event.begin_datumtijd);
            return moviesSaterday;
        }

        public IEnumerable<Film> GetAllForSunday()
        {
            DateTime sunday = new DateTime(2017, 1, 15, 00, 00, 00);
            IQueryable<Film> moviesSunday = ctx.Film.Where(x => x.Event.type == 0 && x.Event.begin_datumtijd.Value.Day == sunday.Day).OrderBy(x => x.Event.begin_datumtijd);
            return moviesSunday;
        }
    }
}